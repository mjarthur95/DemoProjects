/*
* Author: Matthew Arthur
* 
* Date: 9/20/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #391 
* (https://www.reddit.com/r/dailyprogrammer/comments/njxq95/20210524_challenge_391_easy_the_abacaba_sequence/)
* 
* Author's Note: The challenge problem states A-Z, however that would be expensive and time consuming to run and 
* verify. As such, 'E' is chosen as a good stopping place to demonstrate the solution. If you desire to see
* the whole 67,108,863 character solution, change the line
* while (current <= 'E')
* to
* while (current <= 'Z')
*/

//Libraries
#include <iostream>
#include <string>

int main() {

	std::string result = "";
	std::string sequence = "";
	char current = 'A';

	while (current <= 'E') {
		//add the current result with the next letter and the previous sequence
		result = result + current + sequence;

		//create the new sequence
		sequence = sequence + current + sequence;

		//increment by one character
		current++;
	} //while

	//show result
	std::cout << result << std::endl;

	system("pause");
	return 0;
}