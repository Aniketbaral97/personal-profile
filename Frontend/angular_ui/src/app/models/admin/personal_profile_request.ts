export interface AdminPersonalInfo {
    id: string | '00000000-0000-0000-0000-000000000000';
    firstname?: string | '';
    middlename?: string | null;
    lastname?: string | '';
    designations?: string | '';
    address?: string | '';
    phoneNumber?: string | null;
    details?: string | null;
    dateOfBirth?: Date | null;
    gender: number | 0;
    shortText?: string | null;
}

export interface AdminEducation {
    id: string | '00000000-0000-0000-0000-000000000000';
    institution?: string | '';
    degree?: string | '';
    duration?: string | null;
    description?: string | null;
    gradingType: number | 0;
    grading: number | 0;
    startDate?: Date | null;
    endDate?: Date | null;
    isCurrent : boolean
}
export interface AdminGetEducations {
    educations: AdminEducation[];
}
export interface CreateEducations {
    educations: AdminEducation[];
    personalInfoId:string | '00000000-0000-0000-0000-000000000000'
}


export interface AdminExperience {
    id: string | '00000000-0000-0000-0000-000000000000';
    company?: string | null;
    title?: string | null;
    position?: string | null;
    duration?: string | null;
    description?: string | null;
    startDate?: Date | null;
    endDate?: Date | null;
    isCurrent : boolean
}

export interface AdminGetExperiences {
    experiences: AdminExperience[];
}
export interface CreateExperience{
    experiences: AdminExperience[];
    personalInfoId:string | '00000000-0000-0000-0000-000000000000'
}

export interface AdminSkill {
    id: string | '00000000-0000-0000-0000-000000000000';
    type: number | 0;
    typeText?: string | null;
    skill?: string | null;
    level: number | 0;
}

export interface AdminGetManySkillDto {
    skills: AdminSkill[];
}
export interface CreateSkill{
    skills: AdminSkill[];
    personalInfoId:string | '00000000-0000-0000-0000-000000000000'
}

export interface AdminSupportUrl {
    id: string | '00000000-0000-0000-0000-000000000000';
    type: number | 0;
    url?: string | null;
}

export interface AdminGetSupportUrls {
    supportUrls: AdminSupportUrl[];
}
export interface CreateSupportUrl {
    personalInfoId: string | '00000000-0000-0000-0000-000000000000';
    supportUrls: AdminSupportUrl[];
}
