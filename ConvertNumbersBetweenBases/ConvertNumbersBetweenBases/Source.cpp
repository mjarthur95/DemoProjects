/*
* Author: Matthew Arthur
* 
* Date: 10/13/21
* 
* Purpose: Create a program to allow a user to enter a number, the base system the number is in (from 2-16), and the target
* system for the number to be converted to (2-16).
* 
* Example Input : baseSystem = 2, targetSystem = 10, input = 1010
* 
* Output: 10
* 
* Example Input: baseSystem = 10, targetSystem = 2, input = 17
* 
* Output: 10001
*/

//Libraries
#include <iostream>
#include <string>
#include <cmath>
using namespace std;

//Function Declarations
int inputToString(string, int);
string inputToTarget(int, int);

int main() {

	int baseSystem;
	int targetSystem;
	string input;

	cout << "Enter the base number system: ";
	cin >> baseSystem;

	cout << "Enter the target number system: ";
	cin >> targetSystem;

	cout << "Enter the value in base: ";
	cin >> input;

	//convert the string input into a decimal number for ease of use
	int decimal_holder = inputToString(input, baseSystem);

	//convert the decimal_holder into the target system and then return that value as a string
	string output = inputToTarget(decimal_holder, targetSystem);

	//print out the value of the input value in the target base
	cout << input << " in base " << baseSystem << " is equal to " << output << " in base " << targetSystem << endl;

	system("pause");
	return 0;
} //main

int inputToString(string input, int baseSystem) {
	int decimal_holder = 0;

	//convert the string to an integer in decimal
	for (int i = 0; i < input.size(); i++) {
		int temp = 0;
		switch (input[i]) {

		case '0':
			temp = 0;
			break;

		case '1':
			temp = 1;
			break;

		case '2':
			temp = 2;
			break;

		case '3':
			temp = 3;
			break;

		case '4':
			temp = 4;
			break;

		case '5':
			temp = 5;
			break;

		case '6':
			temp = 6;
			break;

		case '7':
			temp = 7;
			break;

		case '8':
			temp = 8;
			break;

		case '9':
			temp = 9;
			break;

		case 'A':
		case 'a':
			temp = 10;
			break;

		case 'B':
		case 'b':
			temp = 11;
			break;

		case 'C':
		case 'c':
			temp = 12;
			break;

		case 'D':
		case 'd':
			temp = 13;
			break;

		case 'E':
		case 'e':
			temp = 14;
			break;

		case 'F':
		case 'f':
			temp = 15;
			break;

		default:

			cout << "Error, input not recongnized." << endl;
			temp = 0;
		} //switch

		temp *= pow(baseSystem, input.size() - (i + 1));
		decimal_holder += temp;
	} //for

	return decimal_holder;
} //inputToString

string inputToTarget(int decimal_holder, int targetSystem) {
	string output = "";

	//if the target system is base 10, simply convert the decimal_holder to a string and return it
	if (targetSystem == 10) {
		output = to_string(decimal_holder);
	}
	//else, convert the number into the target system and then turn it into a string
	else {
		while (decimal_holder > 0) {
			string tempString = "";
			switch (decimal_holder % targetSystem) {
			case 0:
				tempString = '0';
				break;

			case 1:
				tempString = '1';
				break;

			case 2:
				tempString = '2';
				break;

			case 3:
				tempString = '3';
				break;

			case 4:
				tempString = '4';
				break;

			case 5:
				tempString = '5';
				break;

			case 6:
				tempString = '6';
				break;

			case 7:
				tempString = '7';
				break;

			case 8:
				tempString = '8';
				break;

			case 9:
				tempString = '9';
				break;

			case 10:
				tempString = 'A';
				break;

			case 11:
				tempString = 'B';
				break;

			case 12:
				tempString = 'C';
				break;

			case 13:
				tempString = 'D';
				break;

			case 14:
				tempString = 'E';
				break;

			case 15:
				tempString = 'F';
				break;

			default:
				cout << "Error, incorrect input" << endl;
			}

			output = tempString + output;
			decimal_holder /= targetSystem;
		} //switch
	} //for

	return output;
} //inputToTarget
