
-- DROP TABLE "company"
CREATE TABLE "company" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "phone" varchar,
  "email" varchar,
  "address" varchar,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);

-- DROP TABLE "company_branch"

CREATE TABLE "company_branch" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "phone" varchar,
  "address" varchar,
  "company_id" integer,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);

-- DROP TABLE "stadium"

CREATE TABLE "stadium" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "code" varchar,
  "type_id" integer,
  "branch_id" integer,
  "has_recording" integer,
  "min_price" integer,
  "max_price" integer,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);


-- DROP TABLE "stadium_fullied"

CREATE TABLE "stadium_fullied" (
  "id" integer PRIMARY KEY,
  "stadium_id" integer,
  "start_time" integer,
  "end_time" integer,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);

-- DROP TABLE "stadium_price"

CREATE TABLE "stadium_price" (
  "id" integer PRIMARY KEY,
  "price" integer,
  "time_type_id" integer,
  "stadium_id" integer
);

-- DROP TABLE "stadium_price"

CREATE TABLE "stadium_type" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "key" varchar
);

-- DROP TABLE "time_type"

CREATE TABLE "time_type" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "week_day" varchar,
  "time" varchar,
  "interval" varchar
);

-- DROP TABLE "static"

CREATE TABLE "static" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "key" varchar
);

-- DROP TABLE "reserve"

CREATE TABLE "reserve" (
  "id" integer PRIMARY KEY,
  "client_id" integer,
  "stadium_id" integer,
  "date" date,
  "total_amount" integer,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar,
  "is_deleted" integer
);

-- DROP TABLE "client"

CREATE TABLE "client" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "surname" varchar,
  "phone" varchar,
  "email" varchar,
  "user_id" integer,
  "birthdate" date,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);

-- DROP TABLE "company_employee"

CREATE TABLE "company_employee" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "surname" varchar,
  "phone" varchar,
  "email" varchar,
  "branch_id" integer,
  "created_at" date,
  "created_by" varchar,
  "updated_at" date,
  "updated_by" varchar
);



ALTER TABLE "company_branch" ADD FOREIGN KEY ("company_id") REFERENCES "company" ("id");

ALTER TABLE "stadium" ADD FOREIGN KEY ("branch_id") REFERENCES "company_branch" ("id");

ALTER TABLE "stadium" ADD FOREIGN KEY ("type_id") REFERENCES "stadium_type" ("id");

ALTER TABLE "stadium_fullied" ADD FOREIGN KEY ("stadium_id") REFERENCES "stadium" ("id");

ALTER TABLE "stadium_price" ADD FOREIGN KEY ("stadium_id") REFERENCES "stadium" ("id");

ALTER TABLE "stadium_price" ADD FOREIGN KEY ("time_type_id") REFERENCES "time_type" ("id");

ALTER TABLE "reserve" ADD FOREIGN KEY ("stadium_id") REFERENCES "stadium" ("id");

ALTER TABLE "reserve" ADD FOREIGN KEY ("client_id") REFERENCES "client" ("id");

ALTER TABLE "client" ADD FOREIGN KEY ("user_id") REFERENCES "user" ("Id");

ALTER TABLE "company_employee" ADD FOREIGN KEY ("branch_id") REFERENCES "company_branch" ("id");




