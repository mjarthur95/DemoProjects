/*
* Author: Matthew Arthur
* 
* Date: 9/22/21
* 
* Purpose: Solve Reddit Daily Programming Challenge #379
* (https://www.reddit.com/r/dailyprogrammer/comments/cdieag/20190715_challenge_379_easy_progressive_taxation/)
*/

//Librariers
#include <iostream>

int main() {

	int income = 0;

	//user enters their income
	std::cout << "Enter your income: $";
	std::cin >> income;


	if (income > 100000) {
		//max possible value of two lower brackets and how much it exceeds the top bracket for
		std::cout << "$" << 2000 + 17500 + ((income - 100000) * .4) << std::endl;
	} //if
	else if (income > 30000) {
		//max possible value of lower bracket plus how much it exceeds bracket by
		std::cout << "$" << 2000 + ((income - 30000) * .25) << std::endl;
	} //elseif
	else if (income > 10000) {
		//lowest taxable bracket
		std::cout << "$" << (income - 10000) * .1 << std::endl;
	} //elseif
	//no taxable income
	else {
		std::cout << "$0" << std::endl;
	} //else

	system("pause");
	return 0;
} //main