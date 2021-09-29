/*
* Author: Matthew Arthur
* 
* Date: 9/29/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #366
* (https://www.reddit.com/r/dailyprogrammer/comments/98ufvz/20180820_challenge_366_easy_word_funnel_1/)
*/

//Libraries
#include <iostream>
#include <string>

//Function Declaration
bool funnel(std::string, std::string);

int main() {
	std::string first = "", second = "";

	std::cout << "Enter your first string here: ";
	std::cin >> first;

	std::cout << "Enter your second string here: ";
	std::cin >> second;

	if (funnel(first, second)) {
		std::cout << "True" << std::endl;
	} //if
	else {
		std::cout << "False" << std::endl;
	} //else

	system("pause");
	return 0;
} //main


bool funnel(std::string first, std::string second)
{
	//if there is more than one different character, they can not be made equal by removing one character
	if (first.size() != second.size() + 1) {
		return false;
	} //if
	for (int i = 0; i < first.size(); i++) {
		if (!(first.substr(0, i) + first.substr(i + 1)).compare(second)) {
			return true;
		} //if
	} //for

	return false;
} //funnel
