
// cstring_length_mismatchDlg.h : ��� ����
//

#pragma once


// Ccstring_length_mismatchDlg ��ȭ ����
class Ccstring_length_mismatchDlg : public CDialogEx
{
// �����Դϴ�.
public:
	Ccstring_length_mismatchDlg(CWnd* pParent = NULL);	// ǥ�� �������Դϴ�.

// ��ȭ ���� �������Դϴ�.
#ifdef AFX_DESIGN_TIME
	enum { IDD = IDD_CSTRING_LENGTH_MISMATCH_DIALOG };
#endif

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV �����Դϴ�.


// �����Դϴ�.
protected:
	HICON m_hIcon;

	// ������ �޽��� �� �Լ�
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButtonTest1();
};
