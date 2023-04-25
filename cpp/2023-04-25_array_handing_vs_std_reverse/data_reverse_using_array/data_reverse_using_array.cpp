// data_reverse_using_array.cpp : 콘솔 응용 프로그램에 대한 진입점을 정의합니다.
//

#include "stdafx.h"
#include <iostream>

int main()
{
	int org[10] = { 1,2,3,4,5,6,7,8,9,10 };
	int copy[10];

	//------------------------------------------------------------------------------------------
	// data handling c style.
	// 1. limit을 10으로 고정해서 사용하기 때문에 변화에 취약
	// 2. 구문을 읽고 머리로 연산해서 이해해야 하기 때문에 직관적이지 않음.
	//------------------------------------------------------------------------------------------
	for (int i = 0; i < 10; i++) {
		copy[i] = org[10 - i - 1];
	}

	std::cout << "--- using array --- " << std::endl;
	for (int i = 0; i < 10; i++) {
		std::cout << copy[i] << std::endl;
	}

    return 0;
}

