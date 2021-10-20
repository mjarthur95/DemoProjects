package com.example.movieticketapp.adapter;

import android.annotation.SuppressLint;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.movieticketapp.R;

import java.util.List;

public class SeatAdapter extends RecyclerView.Adapter {

    private Context context;
    private List<String> items;
    private OnItemClickListener mListener;

    public interface OnItemClickListener {
        void OnItemClick(View view, String str, int position);
    }

    public void setOnItemClickListener(final OnItemClickListener itemClickListener) {
        this.mListener = itemClickListener;
    }

    public SeatAdapter(Context context, List<String> items) {
        this.context = context;
        this.items = items;
    }

    public void addSeat(String str) {
        items.add(str);
    }

    public String getSeat(int pos) {
        return items.get(pos);
    }

    public void updateItems(List<String> str) {
        items = str;
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        LayoutInflater layoutInflater = LayoutInflater.from(parent.getContext());
        View itemview = layoutInflater.inflate(R.layout.seat_layout, parent, false);
        RecyclerView.ViewHolder viewHolder = new SeatViewHolder(itemview);
        return viewHolder;
    }

    @SuppressLint("ResourceAsColor")
    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        SeatViewHolder seatViewHolder = (SeatViewHolder) holder;
        String str = items.get(position);

        //set the color for the seat
        //E is empty, S is selected, anything else is unavailable
        if (str.equals("E")){
            seatViewHolder.image.setBackgroundResource(R.color.blue);
        }
        else if (str.equals("S")){
            seatViewHolder.image.setBackgroundResource(R.color.red);
        }
        else {
            seatViewHolder.image.setBackgroundResource(R.color.green);
        }

        //set the seat number
        seatViewHolder.number.setText(String.valueOf(position + 1));
    }

    @Override
    public int getItemCount() {
        return items.size();
    }

    public class SeatViewHolder extends RecyclerView.ViewHolder {
        public ImageView image;
        public TextView number;
        public View lyt_parent_seat;

        public SeatViewHolder(View itemView) {
            super(itemView);
            image = itemView.findViewById(R.id.seat_image);
            number = itemView.findViewById(R.id.seat_number);
            lyt_parent_seat = itemView.findViewById(R.id.lyt_parent_seat);

            lyt_parent_seat.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    mListener.OnItemClick(v, items.get(getAdapterPosition()), getAdapterPosition());
                }
            });
        }
    }
}
