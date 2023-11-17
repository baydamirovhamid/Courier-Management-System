ALTER TABLE stadium
ALTER COLUMN has_recording TYPE BOOLEAN USING has_recording::boolean;

ALTER TABLE reserve
ALTER COLUMN is_deleted TYPE BOOLEAN USING is_deleted::boolean;