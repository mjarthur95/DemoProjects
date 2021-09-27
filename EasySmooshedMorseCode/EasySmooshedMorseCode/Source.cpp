/*
* Author:Matthew Arthur
* 
* Date: 9/27/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #380
* (https://www.reddit.com/r/dailyprogrammer/comments/cmd1hb/20190805_challenge_380_easy_smooshed_morse_code_1/)
* 
* Example Input: sos
* 
* Expected Output: ...---...
*/

//Libraries
#include <iostream>
#include <string>
#include <map>

int main() {

	//create a map of chars and strings
	std::map<char, std::string> letterCodes;

	//fill the map with the alphabet and corresponding morse code value
	letterCodes.emplace('a', ".-");
	letterCodes.emplace('b', "-...");
	letterCodes.emplace('c', "-.-.");
	letterCodes.emplace('d', "-..");
	letterCodes.emplace('e', ".");
	letterCodes.emplace('f', "..-.");
	letterCodes.emplace('g', "--.");
	letterCodes.emplace('h', "....");
	letterCodes.emplace('i', "..");
	letterCodes.emplace('j', ".---");
	letterCodes.emplace('k', "-.-");
	letterCodes.emplace('l', ".-..");
	letterCodes.emplace('m', "--");
	letterCodes.emplace('n', "-.");
	letterCodes.emplace('o', "---");
	letterCodes.emplace('p', ".--.");
	letterCodes.emplace('q', "--.-");
	letterCodes.emplace('r', ".-.");
	letterCodes.emplace('s', "...");
	letterCodes.emplace('t', "-");
	letterCodes.emplace('u', "..-");
	letterCodes.emplace('v', "...-");
	letterCodes.emplace('w', ".--");
	letterCodes.emplace('x', "-..-");
	letterCodes.emplace('y', "-.--");
	letterCodes.emplace('z', "--..");

	std::string input = "";
	std::string output = "";

	//user enters the string to be encoded
	std::cout << "Enter your string to be decoded here: ";
	std::cin >> input;

	for (int i = 0; i < input.size(); i++) {
		//add the morse code for each letter to the output
		output += letterCodes.at(input[i]);
	} //for

	std::cout << "The morse code of " << input << " is " << output << std::endl;

	system("pause");
	return 0;
}