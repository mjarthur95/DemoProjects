/*
* Author: Matthew Arthur
* 
* Date: 10/4/21
* 
* Purpose: Demonstrate the algorithm to reverse a vector of integers
*/

//Libraries
#include <iostream>
#include <vector>

int main() {

	std::vector<int> numbers;

	//fill a vector with numbers from 1-100 inclusive
	for (int i = 1; i <= 100; i++) {
		numbers.push_back(i);
	} //for

	//last index in the vector
	int k = numbers.size() - 1;

	//swap the values at the j and k
	for (int j = 0; j < numbers.size() / 2; j++) {
		//a = a + b
		numbers[j] += numbers[k];

		//b = a - b = (a + b) - b = a
		numbers[k] = numbers[j] - numbers[k];

		//a = a - b = a + b - a = b
		numbers[j] -= numbers[k];

		//decrement k
		k--;
	} //for

	//print the values of the vector
	for (int l = 0; l < numbers.size(); l++) {
		std::cout << numbers[l] << " ";
	} //for

	std::cout << std::endl;

	system("pause");
	return 0;
} //main