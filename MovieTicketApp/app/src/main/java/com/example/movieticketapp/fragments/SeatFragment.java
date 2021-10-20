package com.example.movieticketapp.fragments;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.movieticketapp.R;
import com.example.movieticketapp.adapter.SeatAdapter;
import com.example.movieticketapp.model.Ticket;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.firestore.DocumentReference;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import static com.example.movieticketapp.login.Login.username;

public class SeatFragment extends Fragment {

    private static final String TAG = "Seat";
    private static final String TITLE = "Title";
    private static final String THEATER = "Theater";
    private static final String TIME = "Time";
    private static final String ID = "ID";

    private SeatAdapter mAdapter;
    private RecyclerView recyclerView;
    private FirebaseFirestore db;

    private String title;
    private String theater;
    private String time;
    private int id;

    Button buyButton;

    private List<String> items;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {

        //get arguments from TicketDialogFragment
        Bundle args = getArguments();
        title = args.getString(TITLE);
        theater = args.getString(THEATER);
        time = args.getString(TIME);
        time = args.getString(TIME);
        id = args.getInt(ID);

        View RootView = inflater.inflate(R.layout.fragment_seat, container, false);

        buyButton = (Button)RootView.findViewById(R.id.buy_button);

        return RootView;
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        items = new ArrayList<>();

        //get the database
        db = FirebaseFirestore.getInstance();

        //read the array of seats for the specified movie
        db.collection("movies").whereEqualTo("title", title).get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
            @Override
            public void onComplete(@NonNull Task<QuerySnapshot> task) {
                if (task.isSuccessful()) {
                    for (QueryDocumentSnapshot document : task.getResult()) {
                        if (document.exists()) {
                            String str = document.get("seats").toString();
                            //if the theater and time are also the same, add to list
                            if(document.get("time").equals(time) && document.get("title").equals(title)) {
                                for (int i = 0; i < str.length(); i++) {
                                    items.add(str.substring(i, i + 1));
                                }
                            }

                            //notify changes
                            mAdapter.notifyDataSetChanged();
                            Log.d(TAG, "DocumentSnapshot data: " + document.getData());
                        }
                        else {
                            Log.d(TAG, "No such document");
                        }
                    }
                }
                else {
                    Log.d(TAG, "get failed with ", task.getException());
                }
            }
        });

        //create a grid with 5 columns
        GridLayoutManager layoutManager = new GridLayoutManager(getActivity(), 5);

        mAdapter = new SeatAdapter(getActivity(), items);

        //on seat click, change the seat color
        mAdapter.setOnItemClickListener(new SeatAdapter.OnItemClickListener() {
            @Override
            public void OnItemClick(View view, String str, int position) {

                //E is empty, S is selected
                if (items.get(position).equals("E")){
                    items.remove(position);
                    items.add(position, "S");
                }
                else if (items.get(position).equals("S")){
                    items.remove(position);
                    items.add(position, "E");
                }
                else {
                }

                //notify changes
                mAdapter.notifyItemChanged(position);
            }
        });

        recyclerView = (RecyclerView) view.findViewById(R.id.recyclerViewSeat);

        recyclerView.setLayoutManager(layoutManager);
        recyclerView.setAdapter(mAdapter);

        //when buy tickets button is pressed, set the tickets to unavailable and send to payment form
        buyButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //Set selected to unavailable
                for(int i = 0; i < items.size(); i++) {
                    //replace selected with unavailable
                    if (items.get(i).equals("S")) {
                        items.remove(i);
                        items.add(i, "U");
                    }
                }

                //notify changes
                mAdapter.notifyDataSetChanged();

                //update the document with new seating availability
                db.collection("movies").whereEqualTo("id", id).get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                    @Override
                    public void onComplete(@NonNull Task<QuerySnapshot> task) {
                        if (task.isSuccessful()) {
                            for (QueryDocumentSnapshot document : task.getResult()) {
                                if (document.exists()) {

                                    String string = "";
                                    for(int i = 0; i < items.size(); i++){
                                        string  += items.get(i);
                                    }

                                    document.getReference().update("seats", string).addOnSuccessListener(new OnSuccessListener<Void>() {
                                        @Override
                                        public void onSuccess(Void aVoid) {
                                            Log.d(TAG, "successfully updated");
                                        }
                                    });
                                    Log.d(TAG, "DocumentSnapshot data: " + document.getData());
                                }
                                else {
                                    Log.d(TAG, "No such document");
                                }
                            }
                        }
                        else {
                            Log.d(TAG, "get failed with ", task.getException());
                        }
                    }
                });

                //create an authentication number for the user ticket
                Random rand = new Random();
                int authentication = rand.nextInt(10000 - 1000) + 1000;

                //Add the user ticket to the database
                Ticket ticket = new Ticket(authentication, title, theater, time, username);
                db.collection("tickets").add(ticket).addOnSuccessListener(new OnSuccessListener<DocumentReference>() {
                    @Override
                    public void onSuccess(DocumentReference documentReference) {
                        Log.d(TAG, "added");

                        //go to payment fragment
                        PaymentFragment fragment = new PaymentFragment();
                        FragmentTransaction ft = getFragmentManager().beginTransaction();
                        ft.replace(R.id.nav_host_fragment, fragment).addToBackStack(null);
                        ft.commit();
                    }
                });
            }
        });

        //notify changes
        mAdapter.notifyDataSetChanged();
    }
}
