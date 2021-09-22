/*
* Author: Matthew Arthur
* 
* Date: 9/22/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #381
* (https://www.reddit.com/r/dailyprogrammer/comments/dv0231/20191111_challenge_381_easy_yahtzee_upper_section/)
*/

//Libraries
#include <iostream>
#include <vector>

//Function Declarations
int maxOfSix(int, int, int, int, int, int);

int main() {

	//user enters their five rolls
	std::vector<int> rolls;
	std::cout << "Enter the 5 rolls here: ";
	
	//vector is populated with the rolls the user entered
	for (int i = 0; i < 5; i++) {
		int temp = 0;
		std::cin >> temp;
		rolls.push_back(temp);
	} //for

	//counters for the number of times each side was rolled
	int one = 0, two = 0, three = 0, four = 0, five = 0, six = 0;

	for (int j = 0; j < rolls.size(); j++) {
		//increment the counters
		switch (rolls.at(j)) {
		case 1:
			one++;

			break;

		case 2:
			two++;

			break;

		case 3:
			three++;

			break;

		case 4:
			four++;

			break;

		case 5:
			five++;

			break;

		case 6:
			six++;

			break;

		default:
			std::cout << "Error in input" << std::endl;

			break;
		} //switch
	} //for

	//multiply the number of times each side has been rolled by its value
	//any number times 1 is itself
	two *= 2;
	three *= 3;
	four *= 4;
	five *= 5;
	six *= 6;

	//print the output
	std::cout << "The highest possible score is " << maxOfSix(one, two, three, four, five, six) << "." << std::endl;


	system("pause");
	return 0;
} //main

//find the maximum value of the rolls
int maxOfSix(int one, int two, int three, int four, int five, int six)
{
	int temp = one;

	if (temp < two) {
		temp = two;
	} //if
	if (temp < three) {
		temp = three;
	} //if
	if (temp < four) {
		temp = four;
	} //if
	if (temp < five) {
		temp = five;
	} //if
	if (temp < six) {
		temp = six;
	} //if

	return temp;
} //maxOfSix