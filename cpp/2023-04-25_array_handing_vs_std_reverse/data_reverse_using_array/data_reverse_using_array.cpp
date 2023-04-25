// data_reverse_using_array.cpp : �ܼ� ���� ���α׷��� ���� �������� �����մϴ�.
//

#include "stdafx.h"
#include <iostream>

int main()
{
	int org[10] = { 1,2,3,4,5,6,7,8,9,10 };
	int copy[10];

	//------------------------------------------------------------------------------------------
	// data handling c style.
	// 1. limit�� 10���� �����ؼ� ����ϱ� ������ ��ȭ�� ���
	// 2. ������ �а� �Ӹ��� �����ؼ� �����ؾ� �ϱ� ������ ���������� ����.
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
