/*
* Author: Matthew Arthur
* 
* Date: 9/19/21
* 
* Purpose: Solve Reddit Programming Challenge #395
* (https://www.reddit.com/r/dailyprogrammer/comments/o4uyzl/20210621_challenge_395_easy_nonogram_row/)
* 
* Example Input: {1, 0, 1, 1, 1}
* 
* Expected Output: 1 3
*/

//Libraries
#include <iostream>
#include <vector>

//Function Declarations
std::vector<int> nonogramRow(std::vector<int>&);
void printVector(std::vector<int>&);

int main() {
	//input vector for the problem
	std::vector<int> input = { 1, 0, 1, 1, 1 };

	//find the result
	std::vector<int> result = nonogramRow(input);

	//print the result
	printVector(result);

	system("pause");
	return 0;

} //main

//Function Definitions
std::vector<int> nonogramRow(std::vector<int>& nonogramRow)
{
	std::vector<int> result;
	int count = 0;
	//loop through the vector
	for (int i = 0; i < nonogramRow.size(); i++) {
		//if value is true (ie: 1), increment count
		if (nonogramRow.at(i)) {
			count++;
		} //if
		//if value is false (ie: 0) and count is not 0
		else if (!nonogramRow.at(i) && count != 0) {
			//add the count to the vector
			result.push_back(count);
			//reset count
			count = 0;
		} //else if
		else {
			count = 0;
		} //else
	} //for

	//if the loop ends with a 1, it will not have been added to the vector
	if (count != 0) {
		result.push_back(count);
	}

	return result;

} //nonogramRow

void printVector(std::vector<int>& results)
{
	//print the value at each index in the vector
	for (int i = 0; i < results.size(); i++) {
		std::cout << results.at(i) << " ";
	} //for

	//new line for readability
	std::cout << std::endl;

	return;

} //printVector
