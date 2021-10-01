/*
* Author: Matthew Arthur
* 
* Date: 9/30/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #340
* (https://www.reddit.com/r/dailyprogrammer/comments/7cnqtw/20171113_challenge_340_easy_first_recurring/)
*/

//Libraries
#include <iostream>
#include <string>
#include <set>

//Function Declaration
void firstRecurring(std::string);

int main() {

	std::string input = "";

	std::cout << "Enter your string here: ";
	std::cin >> input;

	firstRecurring(input);


	system("pause");
	return 0;
} //main

void firstRecurring(std::string input) {
	//create a set to hold each letter
	std::set<char> letters;

	for (int i = 0; i < input.size(); i++) {
		//add each letter to the set as it appears in the string
		if (letters.find(input[i]) == letters.end()) {
			letters.insert(input[i]);
		} //if
		//if the char already exists in the set, it is the next recurring letter
		else {
			std::cout << "First recurring character: " << input[i] << std::endl;
			std::cout << "Index of the character: " << i << std::endl;

			return;
		}
	}

	std::cout << "No recurring character" << std::endl;
	return;
} //firstRecurring
