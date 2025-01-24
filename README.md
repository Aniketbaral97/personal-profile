# personal-profile

# Personal Profile Portfolio

This repository is designed to create a **personal portfolio** page that showcases key information such as **education**, **experience**, **personal info**, **skills**, **references**, and **support URLs**. This can be a great starting point for building a professional online presence and highlighting your qualifications.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Migration](#migration)
<!-- - [Sections](#sections)
  - [Personal Information](#personal-information)
  - [Education](#education)
  - [Experience](#experience)
  - [Skills](#skills)
  - [References](#references)
  - [Support URL](#support-url) -->

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

## Migration

dotnet ef migrations add Initial -o Persistence/Context/Migrations/AppDbContexts -c AppDbContext --startup-project WebApi  --project Infrastructure/

dotnet ef migrations script -c AppDbContext --project WebApi


dotnet ef migrations add Initial -o Persistence/Context/Migrations/AppIdentityDbContexts -c AppIdentityDbContext --startup-project WebApi  --project Infrastructure/

dotnet ef migrations script -c AppIdentityDbContext --project WebApi