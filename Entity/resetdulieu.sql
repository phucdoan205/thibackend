DELETE FROM Students;
DBCC CHECKIDENT ('Students', RESEED, 0);
DELETE FROM Classes;
DBCC CHECKIDENT ('Classes', RESEED, 0);
-- nhớ để ý phải ở trong database QLLopHoc thì mới reset được dữ liệu về ban đầu để test lại