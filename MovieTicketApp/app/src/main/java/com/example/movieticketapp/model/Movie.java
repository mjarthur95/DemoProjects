package com.example.movieticketapp.model;

public class Movie {

    public Movie(){

    }

    public Movie(int id, String title, String theater, String time) {
        this.id = id;
        this.title = title;
        this.theater = theater;
        this.time = time;
    }

    private int id;
    private String title;
    private String theater;
    private String time;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public void setTheater(String theater) {
        this.theater = theater;
    }

    public String getTheater(){
        return theater;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
