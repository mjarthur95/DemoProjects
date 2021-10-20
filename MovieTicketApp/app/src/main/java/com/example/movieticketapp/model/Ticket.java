package com.example.movieticketapp.model;

public class Ticket {
    private String title;
    private String theater;
    private String time;
    private String username;
    private int authentication;

    public Ticket(){

    }

    public Ticket(int authentication, String title, String theater, String time, String username){
        this.authentication = authentication;
        this.theater = theater;
        this.title = title;
        this.time = time;
        this.username = username;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getTheater() {
        return theater;
    }

    public void setTheater(String theater) {
        this.theater = theater;
    }

    public String getTime() {
        return time;
    }

    public void setTime(String time) {
        this.time = time;
    }

    public int getAuthentication() {
        return authentication;
    }

    public void setAuthentication(int authentication) {
        this.authentication = authentication;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
