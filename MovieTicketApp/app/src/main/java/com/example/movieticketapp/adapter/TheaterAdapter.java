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
import com.example.movieticketapp.model.Theater;

import java.util.List;

public class TheaterAdapter extends RecyclerView.Adapter {

    private Context context;
    private List<Theater> items;

    private OnItemClickListener mListener;

    public interface OnItemClickListener{
        void OnItemClick(View view, Theater theater, int position);
    }

    public void setOnItemClickListener(final OnItemClickListener itemClickListener){
        this.mListener = itemClickListener;
    }

    public TheaterAdapter(Context context, List<Theater> items){
        this.context = context;
        this.items = items;
    }

    public void addTheater(Theater theater){
        items.add(theater);
    }

    public Theater getTheater(int pos){
        return items.get(pos);
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
        View itemview = layoutInflater.inflate(R.layout.theater_layout, parent, false);
        RecyclerView.ViewHolder viewHolder = new TheaterViewHolder(itemview);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        TheaterViewHolder theaterViewHolder = (TheaterViewHolder) holder;
        Theater theater = items.get(position);

        //set the image for the movie theater
        if (theater.getName().equals("AMC")){
            theaterViewHolder.logo.setImageResource(R.mipmap.amc_logo);
        }
        else if (theater.getName().equals("Cinemark")){
            theaterViewHolder.logo.setImageResource(R.mipmap.cinemark_logo);
        }
        else if (theater.getName().equals("Regal Cinema")){
            theaterViewHolder.logo.setImageResource(R.mipmap.regal_cinema_logo);
        }
        else {
            theaterViewHolder.logo.setImageResource(R.mipmap.movie_tavern_poster);
        }

        //set the text boxes
        theaterViewHolder.name.setText(theater.getName());
        theaterViewHolder.address.setText(theater.getAddress());
    }

    @Override
    public int getItemCount() {
        return items.size();
    }

    public class TheaterViewHolder extends RecyclerView.ViewHolder {
        public ImageView logo;
        public TextView name, address;
        public View lyt_parent_theater;
        public TheaterViewHolder(View itemView) {
            super(itemView);
            logo = itemView.findViewById(R.id.theater_logo);
            name = itemView.findViewById(R.id.theater_name);
            address = itemView.findViewById(R.id.theater_address);
            lyt_parent_theater = itemView.findViewById(R.id.lyt_parent_theater);

            lyt_parent_theater.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mListener.OnItemClick(v, items.get(getAdapterPosition()), getAdapterPosition());
                }
            });
        }
    }
}
