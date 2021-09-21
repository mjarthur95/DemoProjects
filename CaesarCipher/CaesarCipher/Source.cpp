/*
* Author: Matthew Arthur
* 
* Date: 9/21/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #387
* (https://www.reddit.com/r/dailyprogrammer/comments/myx3wn/20210426_challenge_387_easy_caesar_cipher/)
*/

//Libraries
#include <iostream>
#include <string>

//Function Declaration
std::string cipher(std::string, int);

int main() {
	std::string letters;
	int shift;

	//Enter the string to be shifted
	std::cout << "Enter a string: ";
	std::cin >> letters;

	//Enter the value of the shift
	std::cout << "Enter the shift value: ";
	std::cin >> shift;

	//print the shifted value
	std::cout << cipher(letters, shift) << std::endl;

	system("pause");
	return 0;
} //main

std::string cipher(std::string letters, int shift) {
	std::string output = "";

	for (int i = 0; i < letters.size(); i++) {
		//if the new letter would be greater than 'z'
		if (letters[i] + shift > 122) {
			//wrap back around to 'a'
			output += (97 + (letters[i] + shift) % 123);
		} //if
		else {
			output += letters[i] + shift;
		} //else
	} //for

	return output;
} //cipher