package com.example.movieticketapp;

import android.app.FragmentTransaction;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.example.movieticketapp.fragments.MovieFragment;
import com.example.movieticketapp.fragments.TicketFragment;

public class HomeActivity extends AppCompatActivity {

    private static final String FRAGMENT = "Fragment";
    private ImageView theater, movie, ticket;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.home_screen_layout);

        //set up the theater image and onclicklistener
        theater = (ImageView)findViewById(R.id.theater);
        theater.setImageResource(R.mipmap.theater);
        theater.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, MainActivity.class);
                intent.putExtra(FRAGMENT, "theater");

                startActivity(intent);
            }
        });

        //set up the movie image and onclicklistener
        movie = (ImageView)findViewById(R.id.movie);
        movie.setImageResource(R.mipmap.movie);
        movie.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, MainActivity.class);
                intent.putExtra(FRAGMENT, "movie");

                startActivity(intent);
            }
        });

        //set up the ticket image and onclicklistener
        ticket = (ImageView)findViewById(R.id.ticket);
        ticket.setImageResource(R.mipmap.ticket);
        ticket.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(HomeActivity.this, MainActivity.class);
                intent.putExtra(FRAGMENT, "ticket");

                startActivity(intent);
            }
        });
    }
}
