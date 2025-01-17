create database MyDB

use MyDB

CREATE TABLE user_tbl (
    id INT IDENTITY(1,1),
    name VARCHAR(100) NOT NULL,
    gender VARCHAR(100) NOT NULL,
    age INT,
	year_of_graduation INT,
    batch_number VARCHAR(50),
    linkedin_id VARCHAR(255),
    email VARCHAR(255) NOT NULL UNIQUE,
	roll_num VARCHAR(255) NOT NULL PRIMARY KEY,
    password VARCHAR(255) NOT NULL
);

SELECT * FROM user_tbl

INSERT INTO user_tbl VALUES 
('Faisal', 'Male', 21, 2026,'2022F','https://www.linkedin.com/in/muhammad-faisal-42080a219/','faisal@example.com','2022F-BCS-152', '123'),
('Saad', 'Male', 21, 'saad@example.com','saad12','321');


CREATE TABLE alumni_group (
    G_id INT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT NOT NULL
);

-- UserGroup Table
CREATE TABLE user_group (
    user_group_id INT IDENTITY(1,1) PRIMARY KEY,
    user_roll VARCHAR(255),   -- Foreign key referencing user_tbl(id)
    group_id INT,  -- Foreign key referencing alumni_group(G_id)
    FOREIGN KEY (user_roll) REFERENCES user_tbl(roll_num),
    FOREIGN KEY (group_id) REFERENCES alumni_group(G_id)
);

INSERT INTO alumni_group VALUES
(1001,'Alumni Tech Enthusiasts','A group dedicated to technology enthusiasts. Join us to explore innovations, share insights, and collaborate on projects that shape the future of tech.'),
(1002,'Entrepreneurs and Innovators','Calling all alumni entrepreneurs, startups, and innovators! Share your ventures, collaborate, and inspire the next generation of creators.'),
(1003,'Career Connections','A professional group for alumni to exchange career tips, share opportunities, and provide industry guidance. Let’s achieve success together!'),
(1004,'Alumni Sports and Fitness','Stay active and connected! Share fitness tips, organize sports events, and celebrate your athletic achievements with fellow alumni.'),
(1005,'Alumni Giving Back','A group dedicated to philanthropy and community service. Join us to support scholarships, fundraisers, and initiatives that give back to our alma mater.'),
(1006,'Alumni Study Abroad Network','Connect with alumni who studied abroad or are currently living overseas. Share experiences, tips, and stay connected globally.')
;
INSERT INTO user_group (user_roll, group_id) 
VALUES
('2022F-BCS-152', 1001);
drop table user_tbl
drop table user_group
drop table alumni_group
SELECT * FROM user_tbl
SELECT * FROM user_group
SELECT * FROM alumni_group

delete from user_group