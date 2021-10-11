/*
* Author: Matthew Arthur
* 
* Date: 10/11/21
* 
* Purpose: Demonstrate the algorithm to check whether a user entered string is a palindrome or not
*/

//Libraries
#include <iostream>
#include <string>

//Function Declarations
bool checkPalindrome(std::string);

int main() {

	std::string input = "";

	std::cout << "Enter your string here: ";
	std::cin >> input;

	if (checkPalindrome(input)) {
		std::cout << input << " is a palindrome." << std::endl;
	} //if
	else {
		std::cout << input << " is not a palindrome." << std::endl;
	} //else

	system("pause");
	return 0;
} //main

//checks whether the input string is a palindrome or not
bool checkPalindrome(std::string input) {
	//last index in input
	int j = input.size() - 1;

	for (int i = 0; i < input.size() / 2; i++) {
		//if the letters are not equal, it is not a palindrome
		if (input[i] != input[j]) {
			return false;
		} //if
		else {
			//decrement the last index
			j--;
		} //else
	} //for

	//if it gets here, all the letters were the same, and it is a palindrome
	return true;
}
