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
import com.example.movieticketapp.model.Ticket;

import java.util.List;

public class TicketAdapter extends RecyclerView.Adapter {

    private Context context;
    private List<Ticket> items;

    public TicketAdapter(Context context, List<Ticket> items){
        this.context = context;
        this.items = items;
    }

    public void addTheater(Ticket ticket){
        items.add(ticket);
    }

    public Ticket getMovie(int pos){
        return items.get(pos);
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
        View itemview = layoutInflater.inflate(R.layout.ticket_layout, parent, false);
        RecyclerView.ViewHolder viewHolder = new TicketAdapter.TicketViewHolder(itemview);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        TicketAdapter.TicketViewHolder ticketViewHolder = (TicketAdapter.TicketViewHolder) holder;
        Ticket ticket = items.get(position);

        //set the image for the tickets the user has
        if (ticket.getTitle().equals("Star Wars: A New Hope")){
            ticketViewHolder.poster.setBackgroundResource(R.mipmap.a_new_hope_poster);
        }
        if (ticket.getTitle().equals("Lord of the Rings: Return of the King")){
            ticketViewHolder.poster.setImageResource(R.mipmap.rotk_poster);
        }
        if (ticket.getTitle().equals("Schindler's List")){
            ticketViewHolder.poster.setImageResource(R.mipmap.schindlers_list_poster);
        }
        if (ticket.getTitle().equals("Knives Out")){
            ticketViewHolder.poster.setImageResource(R.mipmap.knives_out_poster);
        }

        //set the text for the text boxes
        ticketViewHolder.title.setText(ticket.getTitle());
        ticketViewHolder.theater.setText(ticket.getTheater());
        ticketViewHolder.time.setText(ticket.getTime());
        ticketViewHolder.number.setText("Authentification number: " + String.valueOf(ticket.getAuthentication()));
    }

    @Override
    public int getItemCount() {
        return items.size();
    }

    public class TicketViewHolder extends RecyclerView.ViewHolder {
        public ImageView poster;
        public TextView title, theater, time, number;
        public View lyt_parent_movie;

        public TicketViewHolder(View itemView) {
            super(itemView);
            poster = itemView.findViewById(R.id.ticket_image);
            title = itemView.findViewById(R.id.ticket_title);
            theater = itemView.findViewById(R.id.ticket_theater);
            time = itemView.findViewById(R.id.ticket_time);
            number = itemView.findViewById(R.id.ticket_number);
            lyt_parent_movie = itemView.findViewById(R.id.lyt_parent_ticket);
        }
    }
}
