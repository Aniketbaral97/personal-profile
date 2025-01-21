export interface PersonalInfo {
    id: string | '00000000-0000-0000-0000-000000000000';
    firstname: string | '';
    middlename: string | null;
    lastname: string | '';
    designations: string | '';
    address: string | '';
    phoneNumber: string | null;
    details: string | null;
    dateOfBirth: Date | null;
    gender: number | 0;
    shortText: string | null;
}

export interface Education {
    id: string | '00000000-0000-0000-0000-000000000000';
    personalInfoId: string | '00000000-0000-0000-0000-000000000000';
    institution: string | '';
    degree: string | '';
    duration: string | null;
    description: string | null;
    gradingType: number | 0;
    grading: number | 0;
    startDate: Date | null;
    endDate: Date | null;
    isCurrent : boolean
}
export interface GetEducations {
    educations: Education[];
}

export interface Experience {
    id: string | '00000000-0000-0000-0000-000000000000';
    personalInfoId: string | '00000000-0000-0000-0000-000000000000';
    company: string | null;
    position: string | null;
    duration: string | null;
    description: string | null;
    startDate: Date | null;
    endDate: Date | null;
    isCurrent : boolean
}

export interface GetExperiences {
    experiences: Experience[];
}

export interface Skill {
    id: string | '00000000-0000-0000-0000-000000000000';
    type: number | 0;
    typeText: string | null;
    personalInfoId: string | '00000000-0000-0000-0000-000000000000';
    skill: string | null;
    level: number | 0;
}

export interface GetManySkillDto {
    skills: Skill[];
}

export interface SupportUrl {
    id: string | '00000000-0000-0000-0000-000000000000';
    personalInfoId: string | '00000000-0000-0000-0000-000000000000';
    type: number | 0;
    url: string | null;
}

export interface GetSupportUrls {
    supportUrls: SupportUrl[];
}
