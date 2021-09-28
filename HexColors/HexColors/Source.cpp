/*
* Author: Matthew Arthur
* 
* Date: 9/28/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #369
* (https://www.reddit.com/r/dailyprogrammer/comments/a0lhxx/20181126_challenge_369_easy_hex_colors/)
*/

//Libraries
#include <iostream>
#include <string>

//Function Declarations
std::string hexColor(int, int, int);
std::string toHex(int);
std::string hexString(int);

int main() {
	int r = 0, g = 0, b = 0;

	//user enters the three rgb values to be converted to hexadecimal
	std::cout << "Enter your three numbers here (0-255): ";
	std::cin >> r >> g >> b;

	//the hex value is output to the user here
	std::cout << "The hex code for your values is " << hexColor(r, g, b) << std::endl;

	system("pause");
	return 0;
} //main

std::string hexColor(int r, int g, int b)
{
	//return the three hex values + the # sign at the beginning of the string
	return "#" + toHex(r) + toHex(g) + toHex(b);
} //hexColor

std::string toHex(int color)
{
	//the first digit of the hex number
	int first = color / 16;

	//the second digit of the hex number
	int second = color % 16;

	//convert both numbers into strings
	return hexString(first) + hexString(second);
} //toHex

std::string hexString(int half) {
	//switch over the values of the int that would be letters in hex, and convert it to a letter
	switch (half) {
	case 10:

		return "A";

		break;

	case 11:

		return "B";

		break;

	case 12:

		return "C";

		break;

	case 13:

		return "D";

		break;

	case 14:

		return "E";

		break;

	case 15:

		return "F";

		break;

	default:

		break;
	} //switch

	//if the digit is not greater than 9, return the int value as a string
	return std::to_string(half);
} //hexString