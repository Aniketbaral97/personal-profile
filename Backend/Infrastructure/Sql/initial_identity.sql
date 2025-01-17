CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;
CREATE TABLE roles (
    id uuid NOT NULL,
    name character varying(256),
    normalized_name character varying(256),
    concurrency_stamp text,
    CONSTRAINT pk_roles PRIMARY KEY (id)
);

CREATE TABLE users (
    id uuid NOT NULL,
    first_name character varying(50) NOT NULL,
    middle_name character varying(50),
    last_name character varying(50) NOT NULL,
    user_group integer NOT NULL,
    is_active integer NOT NULL,
    designation character varying(50),
    user_name character varying(256),
    normalized_user_name character varying(256),
    email character varying(256),
    normalized_email character varying(256),
    email_confirmed boolean NOT NULL,
    password_hash text,
    security_stamp text,
    concurrency_stamp text,
    phone_number text,
    phone_number_confirmed boolean NOT NULL,
    two_factor_enabled boolean NOT NULL,
    lockout_end timestamp with time zone,
    lockout_enabled boolean NOT NULL,
    access_failed_count integer NOT NULL,
    CONSTRAINT pk_users PRIMARY KEY (id)
);

CREATE TABLE role_claims (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    role_id uuid NOT NULL,
    claim_type text,
    claim_value text,
    CONSTRAINT pk_role_claims PRIMARY KEY (id),
    CONSTRAINT fk_role_claims_roles_role_id FOREIGN KEY (role_id) REFERENCES roles (id) ON DELETE CASCADE
);

CREATE TABLE user_claims (
    id integer GENERATED BY DEFAULT AS IDENTITY,
    user_id uuid NOT NULL,
    claim_type text,
    claim_value text,
    CONSTRAINT pk_user_claims PRIMARY KEY (id),
    CONSTRAINT fk_user_claims_users_user_id FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE user_logins (
    login_provider text NOT NULL,
    provider_key text NOT NULL,
    provider_display_name text,
    user_id uuid NOT NULL,
    CONSTRAINT pk_user_logins PRIMARY KEY (login_provider, provider_key),
    CONSTRAINT fk_user_logins_users_user_id FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE user_roles (
    user_id uuid NOT NULL,
    role_id uuid NOT NULL,
    CONSTRAINT pk_user_roles PRIMARY KEY (user_id, role_id),
    CONSTRAINT fk_user_roles_roles_role_id FOREIGN KEY (role_id) REFERENCES roles (id) ON DELETE CASCADE,
    CONSTRAINT fk_user_roles_users_user_id FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE TABLE user_tokens (
    user_id uuid NOT NULL,
    login_provider text NOT NULL,
    name text NOT NULL,
    value text,
    CONSTRAINT pk_user_tokens PRIMARY KEY (user_id, login_provider, name),
    CONSTRAINT fk_user_tokens_users_user_id FOREIGN KEY (user_id) REFERENCES users (id) ON DELETE CASCADE
);

CREATE INDEX ix_role_claims_role_id ON role_claims (role_id);

CREATE UNIQUE INDEX "RoleNameIndex" ON roles (normalized_name);

CREATE INDEX ix_user_claims_user_id ON user_claims (user_id);

CREATE INDEX ix_user_logins_user_id ON user_logins (user_id);

CREATE INDEX ix_user_roles_role_id ON user_roles (role_id);

CREATE INDEX "EmailIndex" ON users (normalized_email);

CREATE UNIQUE INDEX "UserNameIndex" ON users (normalized_user_name);

INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
VALUES ('20250116083609_Initial', '9.0.1');

COMMIT;