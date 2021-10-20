package com.example.movieticketapp.fragments;

import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.movieticketapp.R;
import com.example.movieticketapp.adapter.MovieAdapter;
import com.example.movieticketapp.model.Movie;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.firestore.FirebaseFirestore;
import com.google.firebase.firestore.QueryDocumentSnapshot;
import com.google.firebase.firestore.QuerySnapshot;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class MovieFragment extends Fragment {

    private static final String TAG = "ANH";
    private static final String DIALOG = "Dialog";
    private static final String TITLE = "Title";
    private static final String TIME = "Time";
    private static final String THEATER = "Theater";
    private static final String ID = "ID";

    private MovieAdapter mAdapter;
    private RecyclerView recyclerView;
    private FirebaseFirestore db;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_movie, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        List<Movie> items = new ArrayList<>();

        //get the database
        db = FirebaseFirestore.getInstance();

        if(getArguments() == null) {
            //read the movies from the database
            db.collection("movies").get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                @Override
                public void onComplete(@NonNull Task<QuerySnapshot> task) {
                    if (task.isSuccessful()) {
                        for (QueryDocumentSnapshot document : task.getResult()) {
                            if (document.exists()) {
                                //add movies to list
                                Movie movie = document.toObject(Movie.class);
                                items.add(movie);

                                //notify changes to list
                                mAdapter.notifyDataSetChanged();
                                Log.d(TAG, "DocumentSnapshot data: " + document.getData());
                            } else {
                                Log.d(TAG, "No such document");
                            }
                        }
                    } else {
                        Log.d(TAG, "get failed with ", task.getException());
                    }
                }

            });
        }
        else {
            //get the movies at that theater
            db.collection("movies").whereEqualTo("theater", getArguments().getString(THEATER)).get().addOnCompleteListener(new OnCompleteListener<QuerySnapshot>() {
                @Override
                public void onComplete(@NonNull Task<QuerySnapshot> task) {
                    if (task.isSuccessful()) {
                        for (QueryDocumentSnapshot document : task.getResult()) {
                            if (document.exists()) {
                                //add movies at a theater to the list
                                Movie movie = document.toObject(Movie.class);
                                items.add(movie);

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
        }

        RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(getActivity());

        mAdapter = new MovieAdapter(getActivity(), items);

        //create a dialog on item click
        mAdapter.setOnItemClickListener(new MovieAdapter.OnItemClickListener() {
            @Override
            public void OnItemClick(View view, Movie movie, int position) {
                Bundle args = new Bundle();
                args.putString(TITLE, movie.getTitle());
                args.putString(TIME, movie.getTime());
                args.putString(THEATER, movie.getTheater());
                args.putInt(ID, movie.getId());
                TicketDialogFragment dialogFragment = new TicketDialogFragment();
                dialogFragment.setArguments(args);
                dialogFragment.show(getFragmentManager(), DIALOG);
            }
        });

        recyclerView = (RecyclerView) view.findViewById(R.id.recyclerViewMovie);

        recyclerView.setLayoutManager(layoutManager);
        recyclerView.setAdapter(mAdapter);
    }

    public static MovieFragment newInstance(String theater) {

        Bundle args = new Bundle();
        args.putString(THEATER, theater);

        MovieFragment fragment = new MovieFragment();
        fragment.setArguments(args);
        return fragment;
    }
}