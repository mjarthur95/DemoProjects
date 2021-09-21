/*
* Author: Matthew Arthur
* 
* Date: 9/21/21
* 
* Purpose: Demonstrate the outcomes of the Monty Hall Problem where the host knows which door the car is behind.
* 
* Additional Background: The Monty Hall Problem is based upon a gameshow where the host asks the player to pick
* 1 of 3 doors. Behind 1 door is a car (or other item the player wants), and behind the other 2 doors are goats 
* (or some other item the player does not want). The host (who knows where the car is) will remove 1 of the 2 
* doors the player did not pick, and ask if the player wants to switch. 
* (https://mathworld.wolfram.com/MontyHallProblem.html)
*/

#include <iostream>
#include <random>
#include <array>
#include <string>

int main() {

	//counters to track the number of successes and failures
	int totalCar = 0;
	int totalGoat = 0;

	//this array represents the 3 doors in the game
	std::string gameDoors[3] = { "Car", "Goat", "Goat" };

	//create the seed for the random engine
	std::random_device seed;

	//create the random engine
	std::default_random_engine doorEngine(seed());

	//create the uniform integer distribution that will uniformly
	//generate random numbers from 0 to 2
	std::uniform_int_distribution<int> uiDist(0, 2);

	//This will run 1000 times
	for (int i = 0; i < 1000; i++) {

		//generate a random value to stand in for the player's choice
		int randomValue = uiDist(doorEngine);

		//if the player has not picked the car, when they switch they will have the car
		if (gameDoors[randomValue] == "Goat") {
			totalCar++;
		} //if 
		//else, if the player has picked the car, when they switch they will always select a goat
		else {
			totalGoat++;
		} //else

	} //for

	std::cout << "The player won the car " << totalCar << " number of times, or " <<
		((double) totalCar / 10) << "% of the games played." << std::endl;

	std::cout << "The player won the goat " << totalGoat << " number of times, or " <<
		((double) totalGoat / 10) << "% of the games played." << std::endl;

	system("pause");
	return 0;

} //main