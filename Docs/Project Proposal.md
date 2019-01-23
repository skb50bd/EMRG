# Project Proposal

## East West University

### Dept. of Computer Science and Engineering

### **CSE411** : Software Engineering and Information System Design

Section: **1**

### Instructor: **Sadia Sharmin**

### **─**

| Group Members                |               |
| ---------------------------- | -------------:|
| Abdullah – Al – Haris Shakib | 2015-1-60-123 |
| Md. Ashiful Arefin           | 2015-1-60-125 |
| Syed Saiful Islam Asik       | 2014-3-60-023 |

_Date of Submission:_ **24 Jan 2019**

___

## Table of Contents

| SL # | Content                | Page # |
| :--- | -----------------------| -----: |
| 1.   | Introduction           | 02     |
| 2.   | Project Description    | 03     |
| 3.   | Existing Solutions     | 04     |
| 4.   | Implementation Details | 05     |
| 5.   | Timeline               | 06     |
| 6.   | References             | 07     |

___

## Introduction

There is a lot of paperwork in educational institutes like colleges and universities. The calculation and planning take enormous amount of time and people if done by hand. Automation can make these tasks easier by doing the heavy-lifting with specialized software.

One of the most time-consuming, erroneous and monotonous tasks is course advising/enrollment. Our goal is to make this process easier and precise, both for the students, faculty and officials.

In our cloud-based application, students will have the opportunity to select the courses they want to enroll-in for the forthcoming semester. The department admin will or will-not approve the enrollments and finalize the courses-to-be-offered and sections.

There will also be a zone for the students where they can discuss and share their findings with others. They will have the place for checking their class schedules for the current semester, and their previous semesters' results.

The faculty will have similar features, so they can check their class schedule, discuss with other faculties, share course materials with students and view their evaluation reports.

This system will help all the students, teachers and officials to do their job easily and efficiently.

___

## Project Description

A short overview of the project-to-be:

1. **Authentication and Authorization:** The application will be secured to prevent unauthorized access. Although, news and part of notices will be anonymously accessible.
2. **Roles:** There will be several roles for the application users, like _admin_, _department admin_, _faculty_ and _student_.
3. **Admin Dashboard:** The application administrator will have a separate area for _department, faculty, student management_. The _rooms_ are also managed by the administrator.
4. **Department Admin Dashboard:** Department administrator is responsible for adding new courses, enrolling new students and accepting students' course enrollment requests.
5. **Online Advising:** Students will have the opportunity to pre-register for the semester to come with the (eligible) courses online. After the pre-registration is over, the department admin will approve the requests and finalize the registration.
6. **Course Groups:** Every section of all the courses will have a group to share the section specific news, events and other study materials. The instructor (faculty) will supervise the corresponding group.
7. **Students' Zone:** Students will be able to view their class schedule, results of the previous semesters and a common place (forum) to discuss about study/university related topics.
8. **Teachers' Zone:** Faculties will have the option to view their class schedule, and submit the results of the examinations. They will also have a forum for discussion.

___

## Existing Solutions

Nowadays every industry has become or is being automated. This industry is no exception. Many well-known universities are using online university portals. Some of them are using partially and others are fully automated and cloud based.

Numerous university management systems are available for free and for premium price. Generic systems require improvising and a lot of configuration. Nevertheless, clearly the customized systems do not work across different domains. Therefore, different institutions need their specific implementations of the system.

We have looked into some existing open-source university management solutions. We will take insights from those solutions. These two are our favorites:

### University Management System

This system is developed by S.M. Minhaz. He used ASP .Net MVC as the application framework. There is the concept of departments, courses, rooms in this project. However, there is no advising or forum features in this project.

### University Course & Result Management System

This project is developed by NRAM Warriors. They used C# and ASP .Net MVC to develop the web application. Admin can add teachers, departments and courses. Students can view results but there's no feature for course section, room, time-schedule and no restriction for course enrollment.

___

## Implementation Details

Here are the tools and libraries we will use to develop the project:

1. Platform

   The application will be developed on Microsoft's open-source **.Net Core** framework. This framework is cross-platform, so the application can run on Windows, Mac or Linux environments.

2. Web Framework / Application Model

   We chose **ASP.Net Core** 2.2 for the application framework. This framework is fast and high performant. Thus, many users can use the application concurrently. We will use **Razor Pages** app-model for its simplicity and scalability.

3. UI Framework

   Bootstrap 4

4. Project Management &amp; Source Control

   **Azure DevOps** (with Git), formally known as _Visual Studio Team Services._ Project Page: [Link](https://dev.azure.com/skb50bd/CSE411)

5. Database & ORM

   **SQLite** with **Entity Framework Core** 2.2, Code-First approach.

6. Others

   The project will need other tools and libraries for fast development and reliability. Here is a short-list:

   + **Programming Languages**: C# 7.3, Typescript.
   + **Identity (Authentication & Authorization)**: Identity Server 4.
   + **Web API Documentation and Testing**: Swagger.
   + **Object Mapping**: AutoMapper.
   + **IDE**: Visual Studio and/or VS Code.

___

## Timeline

The project will be developed with the following timeline in mind:

| Milestones | Description                                                               | Criteria          | ETA         |
| ---------: | :------------------------------------------------------------------------ | ----------------: | ----------: |
| M1         | Requirements Collection, System Design, User stories and Backlogs.        | Proposal approved | 03 Feb 2019 |
| M2         | Initial project creation with identity, and different layers integration. | Backlogs created  | 10 Feb 2019 |
| M3         | Creating the model classes required.                                      | M2 completed      | 17 Feb 2019 |
| M4         | Creating the service layers and implementing Pre-registration.            | M3 completed      | 24 Feb 2019 |
| M5         | Implementing the Forum, and Course Groups.                                | M4 completed      | 10 Mar 2019 |
| M6         | Implementing Class Schedule Viewer.                                       | M5 completed      | 17 Mar 2019 |
| M7         | Finalizing the Project.                                                   | M6 completed      | 31 Mar 2019 |

___

## References

1. [smminhaz/University-Management-system](https://github.com/smminhaz/University-Management-system)
2. [University Course & Result Management System](https://www.youtube.com/watch?v=xO6eizMNZrQ)
