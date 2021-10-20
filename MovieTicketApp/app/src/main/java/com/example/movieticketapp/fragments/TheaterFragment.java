package com.example.movieticketapp.fragments;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.movieticketapp.R;
import com.example.movieticketapp.adapter.TheaterAdapter;
import com.example.movieticketapp.model.Theater;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.List;

public class TheaterFragment extends Fragment {

    private TheaterAdapter mAdapter;
    private RecyclerView recyclerView;
    private FirebaseFirestore db;

    private static final String TAG = "ANH";

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_theater, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        List<Theater> items = new ArrayList<>();

        //get the database
        db = FirebaseFirestore.getInstance();

        //get the theaters from the database
        db.collection("theaters").get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
            @Override
            public void onComplete(@NonNull Task<QuerySnapshot> task) {
                if (task.isSuccessful()) {
                    for (QueryDocumentSnapshot document : task.getResult()) {
                        if (document.exists()) {
                            //add the theaters to the list
                            Theater theater = document.toObject(Theater.class);
                            items.add(theater);

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

        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(getActivity());

        mAdapter = new TheaterAdapter(getActivity(), items);

        //on theater click
        mAdapter.setOnItemClickListener(new TheaterAdapter.OnItemClickListener() {
            @Override
            public void OnItemClick(View view, Theater theater, int position) {
                MovieFragment fragment = MovieFragment.newInstance(theater.getName());
                FragmentTransaction ft = getFragmentManager().beginTransaction();
                ft.replace(R.id.nav_host_fragment, fragment).addToBackStack(null);
                ft.commit();
            }
        });

        recyclerView = (RecyclerView) view.findViewById(R.id.recyclerViewTheater);

        recyclerView.setLayoutManager(layoutManager);
        recyclerView.setAdapter(mAdapter);
    }
}