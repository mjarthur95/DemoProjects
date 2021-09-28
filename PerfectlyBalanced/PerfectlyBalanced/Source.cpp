/*
* Author: Matthew Arthur
* 
* Date: 9/28/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #372
* (https://www.reddit.com/r/dailyprogrammer/comments/afxxca/20190114_challenge_372_easy_perfectly_balanced/)
*/

//Libraries
#include <iostream>
#include <string>
#include <map>

int main() {

	//create a map to hold the amount of times each letter appears
	std::map<char, int> letters;
	std::string input = "";

	//user enters their string here
	std::cout << "Enter your string here: ";
	std::cin >> input;

	//use a for loop to go through each character in the string
	for (int i = 0; i < input.size(); i++) {
		//the the letter isn't in the map already
		if (letters.find(input[i]) == letters.end()) {
			//add the letter with a int value of 0
			letters.emplace(input[i], 0);
		} //if
		//if the letter is in the map
		else {
			//increment the int value
			letters.at(input[i])++;
		} //else
	} //for

	//boolean value to hold whether the string is balanced
	bool balanced = true;
	//iterator to the start of the map
	auto it = letters.begin();

	//for every key in the map
	for (auto l : letters) {
		//if the int value is not equal
		if (it->second != l.second) {
			//the string is not balanced
			balanced = false;
		} //if
	} //foreach

	if (balanced) {
		std::cout << "True" << std::endl;
	} //if
	else {
		std::cout << "False" << std::endl;
	} //else

	system("pause");
	return 0;
} //main