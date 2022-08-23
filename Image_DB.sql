DROP DATABASE IF EXISTS imgDB; -- 만약 imgDB가 존재하면 우선 삭제
CREATE DATABASE imgDB;
USE imgDB;
CREATE TABLE userTBL -- 사용자 테이블
(userID VARCHAR(10) NOT NULL PRIMARY KEY, -- 아이디(PK)
 userNAME VARCHAR(10) NOT NULL, -- 사용자 이름
 userDEPART VARCHAR(10), -- 사용자 소속 부서
 userRANK VARCHAR(5) -- 사용자 직급
);
CREATE TABLE imgTBL -- 이미지 테이블
(userID VARCHAR(10) NOT NULL,
 imgFNAME VARCHAR(30) NOT NULL PRIMARY KEY, -- 이미지 파일 이름
 imgTOPIC VARCHAR(10), -- 이미지 주제
 imgDATE DATE, -- 제작일자
 imgCREATOR VARCHAR(10), -- 제작자
 imgCOL SMALLINT NOT NULL, -- 이미지 행 길이
 imgROW SMALLINT NOT NULL, -- 이미지 열 길이
 imgBYTE BIGINT NOT NULL, -- 이미지 바이트
 imgMEAN SMALLINT NOT NULL, -- 이미지 픽셀 평균값
 imgMIDDLE SMALLINT NOT NULL, -- 이미지 픽셀 중간값
 imgMIN SMALLINT NOT NULL, -- 이미지 픽셀 최솟값
 imgMAX SMALLINT NOT NULL, -- 이미지 픽셀 최대값
 imgDATA MEDIUMBLOB NOT NULL, -- 이미지 데이터
 FOREIGN KEY (userID) REFERENCES userTBL(userID)
);
-- userTBL 데이터 입력
INSERT INTO userTBL VALUES('gens0310', '김진혁', '스마트팩토리', '학생');







-- userTBL 보기
SELECT * FROM userTBL;
-- imgTBL 보기
SELECT * FROM imgTBL;
SELECT * FROM imgTBL WHERE userID = 'gens0310' AND imgFNAME = 'ASD.raw';
-- userTBL 데이터 입력
INSERT INTO userTBL VALUES('gens0310', '김진혁', '스마트팩토리', '학생');
-- imgTBL 데이터 입력
INSERT INTO imgTBL VALUES('gens0310', 'ASD', 'Unknown', '2022-8-20', 'NICK', 128, 128, 128000, 127, 128, 0, 255, 0000);
-- Update
UPDATE imgTBL SET imgTOPIC = 'LENNA', imgDATE = '2022-8-19', imgCREATOR = 'NICK89', imgCOL = 256, imgROW = 256, imgBYTE = 1, imgMEAN = 5, imgMIDDLE = 10, imgMIN = 1, imgMAX = 255, imgDATA = 0000 WHERE imgFNAME = 'ASD';