/*
* Author: Matthew Arthur
* 
* Date: 9/29/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #364
* (https://www.reddit.com/r/dailyprogrammer/comments/8s0cy1/20180618_challenge_364_easy_create_a_dice_roller/)
*/

//Libraries
#include <iostream>
#include <string>
#include <vector>
#include <random>

//Function Declaration
void rollDice(std::string);

int main() {

	std::string nextRoll = "";

	std::cout << "Enter your next roll here (enter q to quit): ";
	std::cin >> nextRoll;

	while (nextRoll.compare("q")) {
		rollDice(nextRoll);

		std::cout << "Enter your next roll here (enter q to quit): ";
		std::cin >> nextRoll;
	}

	system("pause");
	return 0;
}

void rollDice(std::string roll){
	int numberOfDice, sidesOfDice;

	//the number of dice to roll will be the numbers before the "d"
	numberOfDice = std::stoi(roll.substr(0, roll.find("d")));

	//the number of sides of the dice will be the numbers after the "d"
	sidesOfDice = std::stoi(roll.substr(roll.find("d") + 1));

	//create the seed for the random engine
	std::random_device seed;

	//create the random engine
	std::default_random_engine rollEngine(seed());

	//create the uniform integer distribution that will uniformly
	//generate random numbers from 1 to the number of sides of the dice
	std::uniform_int_distribution<int> uiDist(1, sidesOfDice);

	std::vector<int> rolls;

	//add each roll to the vector
	for (int i = 0; i < numberOfDice; i++) {
		rolls.push_back(uiDist(rollEngine));
	} //for

	//find the sum of the rolls
	int sum = 0;
	for (int j = 0; j < rolls.size(); j++) {
		sum += rolls.at(j);
	} //for

	//print the sum of the rolls
	std::cout << sum << ": ";

	//print each individual roll
	for (int k = 0; k < rolls.size(); k++) {
		std::cout << rolls.at(k) << " ";
	} //for

	//extra line for readability
	std::cout << std::endl;

	return;
} //rollDice