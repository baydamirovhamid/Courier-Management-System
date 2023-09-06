﻿CREATE TRIGGER MANAGEMENT_COMPANY_TG
BEFORE
INSERT ON "MANAGEMENT_COMPANY"
FOR EACH ROW EXECUTE PROCEDURE MANAGEMENT_COMPANY_TG_FUNC();

CREATE TRIGGER BUILDING_TG
BEFORE
INSERT ON "BUILDING"
FOR EACH ROW EXECUTE PROCEDURE BUILDING_TG_FUNC();

CREATE TRIGGER APARTMENT_TG
BEFORE
INSERT ON "APARTMENT"
FOR EACH ROW EXECUTE PROCEDURE APARTMENT_TG_FUNC();

CREATE TRIGGER EMPLOYEE_ROLE_TG
BEFORE
INSERT ON "EMPLOYEE_ROLE"
FOR EACH ROW EXECUTE PROCEDURE EMPLOYEE_ROLE_TG_FUNC();

CREATE TRIGGER EMPLOYEE_TG
BEFORE
INSERT ON "EMPLOYEE"
FOR EACH ROW EXECUTE PROCEDURE EMPLOYEE_TG_FUNC();

CREATE TRIGGER SUBSCRIBER_TG
BEFORE
INSERT ON "SUBSCRIBER"
FOR EACH ROW EXECUTE PROCEDURE SUBSCRIBER_TG_FUNC();

CREATE TRIGGER USER_TG
BEFORE
INSERT ON "USER"
FOR EACH ROW EXECUTE PROCEDURE USER_TG_FUNC();

CREATE TRIGGER INVOICE_TYPE_TG
BEFORE
INSERT ON "INVOICE_TYPE"
FOR EACH ROW EXECUTE PROCEDURE INVOICE_TYPE_TG_FUNC();

CREATE TRIGGER INVOICE_TG
BEFORE
INSERT ON "INVOICE"
FOR EACH ROW EXECUTE PROCEDURE INVOICE_TG_FUNC();

CREATE TRIGGER AGREEMENT_DOC_TG
BEFORE
INSERT ON "AGREEMENT_DOC"
FOR EACH ROW EXECUTE PROCEDURE AGREEMENT_DOC_TG_FUNC();

CREATE TRIGGER AGREEMENT_TG
BEFORE
INSERT ON "AGREEMENT"
FOR EACH ROW EXECUTE PROCEDURE AGREEMENT_TG_FUNC();

CREATE TRIGGER USER_AGREEMENT_TG
BEFORE
INSERT ON "USER_AGREEMENT"
FOR EACH ROW EXECUTE PROCEDURE USER_AGREEMENT_TG_FUNC();

CREATE TRIGGER SERVICE_TG
BEFORE
INSERT ON "SERVICE"
FOR EACH ROW EXECUTE PROCEDURE SERVICE_TG_FUNC();

CREATE TRIGGER AGREEMENT_SERVICE_TG
BEFORE
INSERT ON "AGREEMENT_SERVICE"
FOR EACH ROW EXECUTE PROCEDURE AGREEMENT_SERVICE_TG_FUNC();