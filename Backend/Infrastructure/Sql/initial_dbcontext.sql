CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;
CREATE TABLE educations (
    id uuid NOT NULL,
    personal_info_id uuid NOT NULL,
    institution text NOT NULL,
    degree text NOT NULL,
    duration text NOT NULL,
    description text NOT NULL,
    grading_type integer NOT NULL,
    grading double precision NOT NULL,
    start_date date,
    end_date date,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    CONSTRAINT pk_educations PRIMARY KEY (id)
);

CREATE TABLE experiences (
    id uuid NOT NULL,
    personal_info_id uuid NOT NULL,
    company text NOT NULL,
    position text NOT NULL,
    duration text NOT NULL,
    description text NOT NULL,
    is_current boolean NOT NULL,
    start_date date NOT NULL,
    end_date date,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    CONSTRAINT pk_experiences PRIMARY KEY (id)
);

CREATE TABLE personal_infos (
    id uuid NOT NULL,
    firstname text NOT NULL,
    lastname text NOT NULL,
    designations text NOT NULL,
    address text NOT NULL,
    phone_number text,
    details text,
    short_text text,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    CONSTRAINT pk_personal_infos PRIMARY KEY (id)
);

CREATE TABLE skills (
    id uuid NOT NULL,
    personal_info_id uuid NOT NULL,
    type integer NOT NULL,
    skill text NOT NULL,
    level integer NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    CONSTRAINT pk_skills PRIMARY KEY (id)
);

CREATE TABLE support_urls (
    id uuid NOT NULL,
    personal_info_id uuid NOT NULL,
    type integer NOT NULL,
    url text NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone NOT NULL,
    CONSTRAINT pk_support_urls PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20250116082832_Initial', '9.0.1');

ALTER TABLE personal_infos ADD date_of_birth date NOT NULL DEFAULT DATE '-infinity';

ALTER TABLE personal_infos ADD gender integer NOT NULL DEFAULT 0;

ALTER TABLE personal_infos ADD middlename text;

ALTER TABLE experiences ADD title text NOT NULL DEFAULT '';

ALTER TABLE educations ADD is_current boolean NOT NULL DEFAULT FALSE;

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20250117042205_UpdatedPersonalInfoTable', '9.0.1');

COMMIT;