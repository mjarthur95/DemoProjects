package com.example.movieticketapp.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.movieticketapp.R;
import com.example.movieticketapp.model.Movie;

import java.util.List;

public class MovieAdapter extends RecyclerView.Adapter {
    private Context context;
    private List<Movie> items;
    private OnItemClickListener mListener;

    public interface OnItemClickListener {
        void OnItemClick(View view, Movie movie, int position);
    }

    public void setOnItemClickListener(final OnItemClickListener itemClickListener) {
        this.mListener = itemClickListener;
    }

    public MovieAdapter(Context context, List<Movie> items) {
        this.context = context;
        this.items = items;
    }

    public void addMovie(Movie movie) {
        items.add(movie);
    }

    public Movie getMovie(int pos) {
        return items.get(pos);
    }

    public void updateItems(List<Movie> movies) {
        items = movies;
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
        View itemview = layoutInflater.inflate(R.layout.movie_layout, parent, false);
        RecyclerView.ViewHolder viewHolder = new MovieViewHolder(itemview);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        MovieAdapter.MovieViewHolder movieViewHolder = (MovieAdapter.MovieViewHolder) holder;
        Movie movie = items.get(position);

        //set the image for the movie posters
        if (movie.getTitle().equals("Star Wars: A New Hope")) {
            movieViewHolder.poster.setImageResource(R.mipmap.a_new_hope_poster);
        }
        else if (movie.getTitle().equals("Lord of the Rings: Return of the King")) {
            movieViewHolder.poster.setImageResource(R.mipmap.rotk_poster);
        }
        else if (movie.getTitle().equals("Schindler's List")) {
            movieViewHolder.poster.setImageResource(R.mipmap.schindlers_list_poster);
        }
        else {
            movieViewHolder.poster.setImageResource(R.mipmap.knives_out_poster);
        }

        //set the text boxes
        movieViewHolder.title.setText(movie.getTitle());
        movieViewHolder.time.setText(movie.getTime());
        movieViewHolder.theater.setText(movie.getTheater());
}

    @Override
    public int getItemCount() {
        return items.size();
    }

    public class MovieViewHolder extends RecyclerView.ViewHolder {
        public ImageView poster;
        public TextView title, time, theater;
        public View lyt_parent_movie;

        public MovieViewHolder(View itemView) {
            super(itemView);
            poster = itemView.findViewById(R.id.movie_image);
            title = itemView.findViewById(R.id.movie_title);
            time = itemView.findViewById(R.id.movie_time);
            theater = itemView.findViewById(R.id.movie_theater);
            lyt_parent_movie = itemView.findViewById(R.id.lyt_parent_movie);

            lyt_parent_movie.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mListener.OnItemClick(v, items.get(getAdapterPosition()), getAdapterPosition());
                }
            });
        }
    }
}
