/*
* Author: Matthew Arthur
* 
* Date: 9/27/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #374
* (https://www.reddit.com/r/dailyprogrammer/comments/akv6z4/20190128_challenge_374_easy_additive_persistence/)
*/

//Libraries
#include <iostream>

int main() {

	int input = 0;
	int count = 0;
	int output = 0;

	//user enters the number
	std::cout << "Enter your number here: ";
	std::cin >> input;

	//temp holder so that input can be used in the final statement
	int temp = input;

	//while the number is not in single digits
	while (temp > 9) {

		//each loop will shift the value of temp 1 digit to the right
		for (; temp > 0; temp /= 10) {
			//add the rightmost digit to the current number
			output += (temp % 10);
		} //for

		//set temp for the next loop
		temp = output;

		//reset output for the next loop
		output = 0;

		//increment count
		count++;
	} //while

	//output the result to the user
	std::cout << input << " can be turned into a single digit number by summing the digits in " << count << " step(s)." << std::endl;

	system("pause");
	return 0;
}