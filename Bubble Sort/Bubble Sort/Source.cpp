/*
* Author: Matthew Arthur
* 
* Date: 9/20/21
* 
* Purpose: To show the author's understanding of a standard bubble sort algorithm in ascending order
* 
* Example Input: 20 5 30 100 9
* 
* Expected Output 5 9 20 30 100
*/

//Libraries
#include <iostream>

//Global Variable
const int SIZE = 5;

int main() {

	//create an array of SIZE (in this case, 5)
	int array[SIZE];

	//user instructions
	std::cout << "Enter " << SIZE <<" numbers: ";
	//populate the array from user input
	for (int i = 0; i < SIZE; i++) {
		std::cin >> array[i];
	} //for

	//bubble sort
	for (int i = 0; i < SIZE; i++) {
		for (int j = 0; j < SIZE; j++) {
			//if an item to the left is greater than an item to the right, switch the items
			if (array[i] < array[j]) {
				int temp = array[i];
				array[i] = array[j];
				array[j] = temp;
			} //if
		} //for
	} //for

	//display the sorted array
	for (int i = 0; i < SIZE; i++) {
		std::cout << array[i] << " ";
	} //for

	//extra line for readability
	std::cout << std::endl;

	//pause for the user to see the output
	system("pause");
	return 0;
}