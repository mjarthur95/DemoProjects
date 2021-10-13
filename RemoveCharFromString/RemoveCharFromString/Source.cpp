/*
* Author: Matthew Arthur
* 
* Date: 10/12/21
* 
* Purpose: Demonstrate the algorithm to take a string and char input, and remove every instance
* of that char from the string
*/

//Libraries
#include <iostream>
#include <string>

//Function Declarations
std::string removeChar(std::string, char);

int main() {

	std::string stringInput = "";
	char charInput = 'a';

	std::cout << "Enter your string here: ";
	std::cin >> stringInput;

	std::cout << "Enter the char to be removed here: ";
	std::cin >> charInput;

	std::cout << stringInput << " minus " << charInput << " is " <<
		removeChar(stringInput, charInput) << std::endl;

	system("pause");
	return 0;
} //main

std::string removeChar(std::string stringInput, char charInput) {

	for (int i = 0; i < stringInput.size();) {
		//if the char at i is the char to be removed
		if (stringInput[i] == charInput) {
			//remove the char
			stringInput = stringInput.substr(0, i) + stringInput.substr(i + 1);
		} //if
		else {
			//increment i
			i++;
		} //else
	} //for

	return stringInput;
} //removeChar