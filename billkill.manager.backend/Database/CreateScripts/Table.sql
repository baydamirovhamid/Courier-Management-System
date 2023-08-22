﻿CREATE TABLE "MANAGEMENT_COMPANY" (
  "ID" INTEGER PRIMARY KEY,
  "NAME" VARCHAR,
  "EMAIL" VARCHAR,
  "PHONE" VARCHAR,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "BUILDING" (
  "ID" INTEGER PRIMARY KEY,
  "NAME" VARCHAR,
  "ADDRESS" VARCHAR,
  "COMPANY_ID" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "APARTMENT" (
  "ID" INTEGER PRIMARY KEY,
  "NAME" VARCHAR,
  "PHONE" VARCHAR,
  "VOLUME" VARCHAR,
  "BUILDING_ID" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "EMPLOYEE_ROLE" (
  "ID" INTEGER PRIMARY KEY,
  "NAME" VARCHAR,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "EMPLOYEE" (
  "ID" INTEGER PRIMARY KEY,
  "USER_ID" INTEGER,
  "ROLE_ID" INTEGER,
  "COMPANY_ID" INTEGER
);

CREATE TABLE "SUBSCRIBER" (
  "ID" INTEGER PRIMARY KEY,
  "USER_ID" INTEGER,
  "SUBSCRIBER_CODE" VARCHAR
);

CREATE TABLE "INVOICE_TYPE" (
  "ID" INTEGER PRIMARY KEY,
  "NAME" VARCHAR,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "INVOICE" (
  "ID" INTEGER PRIMARY KEY,
  "SUBSCRIBER_ID" INTEGER,
  "PRICE" INTEGER,
  "TRANS_ID" VARCHAR,
  "TYPE_ID" INTEGER,
  "AGREEMENT_ID" INTEGER,
  "SERVICE_ID" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "AGREEMENT_DOC" (
  "ID" INTEGER PRIMARY KEY,
  "AGREEMENT_ID" INTEGER,
  "CONTENT" VARCHAR,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "AGREEMENT" (
  "ID" INTEGER PRIMARY KEY,
  "NUM" VARCHAR,
  "MTK_NUM" VARCHAR,
  "APARTMENT_ID" INTEGER,
  "START_DATE" TIMESTAMP,
  "END_DATE" TIMESTAMP,
  "GRACE_PERIOD" INTEGER,
  "NAME" VARCHAR,
  "ADDRESS" VARCHAR,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "USER_AGREEMENT" (
  "ID" INTEGER PRIMARY KEY,
  "AGREEMENT_ID" INTEGER,
  "SUBSCRIBER_ID" INTEGER,
  "STATUS" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "SERVICE" (
  "ID" INTEGER PRIMARY KEY,
  "BUILDING_ID" INTEGER,
  "NAME" VARCHAR,
  "PRICE" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);

CREATE TABLE "AGREEMENT_SERVICE" (
  "ID" INTEGER PRIMARY KEY,
  "AGREEMENT_ID" INTEGER,
  "SERVICE_ID" INTEGER,
  "PRICE" INTEGER,
  "CREATED_AT" TIMESTAMP,
  "CREATED_BY" VARCHAR,
  "UPDATED_AT" TIMESTAMP,
  "UPDATED_BY" VARCHAR
);