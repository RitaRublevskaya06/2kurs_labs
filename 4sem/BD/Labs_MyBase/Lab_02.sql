-- ��������� ������� "�����" � "������"
ALTER TABLE �����
ADD CONSTRAINT FK_�����_�����
FOREIGN KEY (�����_ID) REFERENCES ������(ID) ON DELETE CASCADE;

-- ��������� ������� "������" � "����������"
ALTER TABLE ������
ADD CONSTRAINT FK_������_����������
FOREIGN KEY (����������_ID) REFERENCES ����������(ID) ON DELETE CASCADE;

-- ��������� ������� "������" � "������"
ALTER TABLE ������
ADD CONSTRAINT FK_������_�����
FOREIGN KEY (�����_ID) REFERENCES ������(ID) ON DELETE CASCADE;
