/*
* Author: Matthew Arthur
* 
* Date: 9/19/21
* 
* Purpose: Solve Reddit Programming Challenge #393
* (https://www.reddit.com/r/dailyprogrammer/comments/nucsik/20210607_challenge_393_easy_making_change/)
* 
* Example Input: 526
* 
* Expected Output: 3
*/

//Libraries
#include <iostream>

int main() {

	int input = 0;
	int coins = 0;
	std::cout << "Enter the value to be broken down into coins: ";
	std::cin >> input;

	//500 currency coins
	coins += (input / 500);
	input %= 500;

	//100 currency coins
	coins += (input / 100);
	input %= 100;

	//50 currency coins
	coins += (input / 50);
	input %= 50;

	//25 currency coins
	coins += (input / 25);
	input %= 25;

	//5 currency coins
	coins += (input / 5);
	input %= 5;

	//all remaining coins as 1
	coins += input;

	std::cout << "Number of coins: " << coins << std::endl;


	system("pause");
	return 0;
}