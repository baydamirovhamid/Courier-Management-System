CREATE TABLE [customer] (
  [id] integer PRIMARY KEY,
  [name] nvarchar(255),
  [surname] nvarchar(255),
  [address] nvarchar(255),
  [contact] nvarchar(255),
  [created_at] timestamp,
  [created_by] varchar,
  [updated_at] timestamp,
  [updated_by] varchar
)
GO

CREATE TABLE [courier] (
  [id] integer PRIMARY KEY,
  [name] nvarchar(255),
  [surname] nvarchar(255),
  [contact] nvarchar(255),
  "created_at" timestamp,
  "created_by" varchar,
  "updated_at" timestamp,
  "updated_by" varchar,
  "is_deleted" integer
)
GO

CREATE TABLE [package] (
  [id] integer PRIMARY KEY,
  [trackingnumber] nvarchar(255),
  [weight] integer,
  [status] boolean,
  [customer_id] integer,
  [courier_id] integer,
  "created_at" timestamp,
  "created_by" varchar,
  "updated_at" timestamp,
  "updated_by" varchar,
  "is_deleted" integer
)
GO

CREATE TABLE [payment] (
  [id] integer PRIMARY KEY,
  [amount] integer,
  [payment_date] datetime,
  [customer_id] integer
)
GO

ALTER TABLE [package] ADD FOREIGN KEY ([customer_id]) REFERENCES [customer] ([id])
GO

ALTER TABLE [package] ADD FOREIGN KEY ([courier_id]) REFERENCES [courier] ([id])
GO

ALTER TABLE [payment] ADD FOREIGN KEY ([customer_id]) REFERENCES [customer] ([id])
GO
