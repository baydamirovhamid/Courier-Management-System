﻿CREATE TRIGGER CUSTOMER_TG
BEFORE
INSERT ON "customer"
FOR EACH ROW EXECUTE PROCEDURE CUSTOMER_TG_FUNC();

CREATE TRIGGER COURIER_TG
BEFORE
INSERT ON "courier"
FOR EACH ROW EXECUTE PROCEDURE COURIER_TG_FUNC();

CREATE TRIGGER PACKAGE_TG
BEFORE
INSERT ON "package"
FOR EACH ROW EXECUTE PROCEDURE PACKAGE_TG_FUNC();

CREATE TRIGGER PAYMENT_TG
BEFORE
INSERT ON "payment"
FOR EACH ROW EXECUTE PROCEDURE PAYMENT_TG_FUNC();

