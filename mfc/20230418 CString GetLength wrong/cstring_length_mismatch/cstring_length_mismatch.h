
// cstring_length_mismatch.h : PROJECT_NAME ���� ���α׷��� ���� �� ��� �����Դϴ�.
//

#pragma once

#ifndef __AFXWIN_H__
	#error "PCH�� ���� �� ������ �����ϱ� ���� 'stdafx.h'�� �����մϴ�."
#endif

#include "resource.h"		// �� ��ȣ�Դϴ�.


// Ccstring_length_mismatchApp:
// �� Ŭ������ ������ ���ؼ��� cstring_length_mismatch.cpp�� �����Ͻʽÿ�.
//

class Ccstring_length_mismatchApp : public CWinApp
{
public:
	Ccstring_length_mismatchApp();

// �������Դϴ�.
public:
	virtual BOOL InitInstance();

// �����Դϴ�.

	DECLARE_MESSAGE_MAP()
};

extern Ccstring_length_mismatchApp theApp;