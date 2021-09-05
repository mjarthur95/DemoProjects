/*
* Author: Matthew Arthur
* 
* Date: 9/5/21
* 
* Purpose: Solve Reddit Programming Challenge #399 
* (https://www.reddit.com/r/dailyprogrammer/comments/onfehl/20210719_challenge_399_easy_letter_value_sum/)
*/

//Libraries
#include <iostream>
#include <string>

int main() {

	int sum = 0;
	std::string input;

	//user inputs the desired string
	std::cout << "Enter your string here: ";
	std::cin >> input;

	//add the value at each index to the sum
	for(auto s : input) {
		//strings are input as lowercase, as per the challenge
		sum += s - 96;
	}

	//output the value for the user
	std::cout << "Sum: " << sum << std::endl;

	system("pause");
	return 0;
}