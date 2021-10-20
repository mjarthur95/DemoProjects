package com.example.movieticketapp;

import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.navigation.NavController;
import androidx.navigation.NavGraph;
import androidx.navigation.NavInflater;
import androidx.navigation.Navigation;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.navigation.ui.NavigationUI;

public class MainActivity extends AppCompatActivity {

    private static final String FRAGMENT = "Fragment";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        //get what was clicked from HomeActivity
        Intent intent = getIntent();
        String page = intent.getStringExtra(FRAGMENT);

        //set up the view for the activity and nav bar
        setContentView(R.layout.activity_main);
        BottomNavigationView navView = findViewById(R.id.nav_view);
        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        AppBarConfiguration appBarConfiguration = new AppBarConfiguration.Builder(
                R.id.navigation_theaters, R.id.navigation_movies, R.id.navigation_tickets)
                .build();
        NavController navController = Navigation.findNavController(this, R.id.nav_host_fragment);

        NavInflater navInflater = navController.getNavInflater();
        NavGraph graph = navInflater.inflate((R.navigation.mobile_navigation));

        //use what was clicked on HomeActivity to determine what fragment to load
        if(page.equals("theater")){
            graph.setStartDestination(R.id.navigation_theaters);
        }
        else if(page.equals("movie")){
            graph.setStartDestination(R.id.navigation_movies);
        }
        else {
            graph.setStartDestination(R.id.navigation_tickets);
        }

        navController.setGraph(graph);

        NavigationUI.setupActionBarWithNavController(this, navController, appBarConfiguration);
        NavigationUI.setupWithNavController(navView, navController);
    }

    //add home button icon on action bar
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    //return to the HomeActivity
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        startActivity(new Intent(MainActivity.this, HomeActivity.class));
        return super.onOptionsItemSelected(item);
    }
}