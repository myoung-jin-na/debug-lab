// data_reverse_using_std_reverse.cpp : �ܼ� ���� ���α׷��� ���� �������� �����մϴ�.
//

#include "stdafx.h"
#include <iostream>
#include <vector>

int main()
{
	std::vector<int> org = { 1,2,3,4,5,6,7,8,9,10 };
	std::vector<int> copy = org;

	//-----------------------------------------------
	// data handling. easy and no error. 
	//-----------------------------------------------
	std::reverse(copy.begin(), copy.end());

	std::cout << "--- using std::reverse --- " << std::endl;

	for (auto it : copy) {
		std::cout << it << std::endl;
	}

    return 0;
}

