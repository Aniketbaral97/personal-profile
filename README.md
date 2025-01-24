# personal-profile

# Personal Profile Portfolio

This repository is designed to create a **personal portfolio** page that showcases key information such as **education**, **experience**, **personal info**, **skills**, **references**, and **support URLs**. This can be a great starting point for building a professional online presence and highlighting your qualifications.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
<!-- - [Sections](#sections)
  - [Personal Information](#personal-information)
  - [Education](#education)
  - [Experience](#experience)
  - [Skills](#skills)
  - [References](#references)
  - [Support URL](#support-url) -->
- [Initial Identity](#indentity-sql)

## Introduction
Welcome to my personal profile repository! This is where I showcase details about my career, education, and skills. The repository includes sections for:
- Personal information
- Educational background
- Professional experience
- Technical skills
- References
- Support or contact links

Feel free to explore and view my portfolio page or use the structure to create your own personal portfolio page!

## Features
- **Customizable sections** for personal information, education, work experience, skills, references, and URLs.
- **Easy-to-update content** to keep the portfolio up-to-date.
- **Professional presentation** of key details about your career and achievements.

## Technologies Used
- **.NET** and **C#** for backend development and API creation.
- **Angular** for frontend development and building interactive UIs.
- **CSS** for styling and creating visually appealing designs.
- **TypeScript** for writing scalable and maintainable JavaScript code in Angular.

## User creation feature (Incomplete)

The authentication feature for user creation is not completely finished yet. However, you can manually add a default user to the database by running the following SQL script.

### SQL to Add Default User

You can add the default user by executing the following SQL query:

```sql
INSERT INTO users (id ,first_name, middle_name, last_name, is_active, 
    user_group, user_name, normalized_user_name, email, normalized_email, email_confirmed, 
    password_hash, security_stamp, concurrency_stamp, phone_number, 
    phone_number_confirmed, two_factor_enabled, lockout_end, lockout_enabled, 
    access_failed_count ) 
VALUES 
('c5a18703-fe75-4ee7-8785-72590b11fb9d','Super','','Group',1, 1,'admin', 'ADMIN',
'kpocompany2017@gmail.com','KPOCOMPANY2017@GMAIL.COM',true, 
'AQAAAAIAAYagAAAAEBXFy1UK43LeFPXeUX6a+AFPJGW3xgalkzc6SVA4wAHdwWmLKfZRqcNECHHAoDVnOg==',
 'AMG7DXQCSZPFQ76H52DM2DEJ6EDJYH55','c5a18703-fe75-4ee7-8785-72590b11fb9d',NULL,
 true,false,NULL,false,0);

INSERT INTO user_claims(user_id,claim_type,claim_value) 
VALUES 
('c5a18703-fe75-4ee7-8785-72590b11fb9d','TopicCreatorApi','Admin');

INSERT INTO user_claims (user_id,claim_type,claim_value)  
VALUES 
('c5a18703-fe75-4ee7-8785-72590b11fb9d','TopicCreatorApi','Developer');\

Since the password is stored in a hashed format (e.g., AQAAAAIAAYagAAAAEBXFy1UK43LeFPXeUX6a+AFPJGW3xgalkzc6SVA4wAHdwWmLKfZRqcNECHHAoDVnOg==), you will need to visit a website that allows you to hash your new password and then replace the hash in the SQL query above with your new password hash.

Once the password is changed, you will be able to log in using the username admin and your newly set password. 


## Screenshots
![alt text](<Screenshot 2025-01-24 115932-1.png>) ![alt text](<Screenshot 2025-01-24 115949.png>) ![alt text](<Screenshot 2025-01-24 120001.png>) ![alt text](<Screenshot 2025-01-24 120055.png>)