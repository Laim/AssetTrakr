import random
import uuid

names = ["Alpha", "Bravo", "Charlie", "Delta", "Echo"]
order_refs = [f"ORD{str(i).zfill(4)}" for i in range(0, 100)]  # Generate 1000 unique order references

created_date = "2024-05-20 22:03:02.7135149+00:00"
updated_date = "2024-05-20 22:03:02.7135149+00:00"
created_by = "DemoData"
updated_by = "DemoData"

def generate_insert_statements_with_unique_order_refs():
    insert_statements = []
    user_agreement_ids = set()
    while len(user_agreement_ids) < 5000:
        user_agreement_ids.add(str(uuid.uuid4()))  # Generate unique UUIDs

    for user_agreement_id, order_ref in zip(user_agreement_ids, order_refs):
        name = random.choice(names)
        price = round(random.uniform(10.0, 1000.0), 2)
        payment_frequency = "Once"
        statement = f'''
INSERT INTO Contracts (Name, OrderRef, Price, PaymentFrequency, UserAgreementId, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy) 
VALUES ("{name}", "{order_ref}", "{price}", "{payment_frequency}", "{user_agreement_id}", "{created_date}", "{updated_date}", "{created_by}", "{updated_by}");
'''
        insert_statements.append(statement.strip())
    return insert_statements

insert_statements_with_unique_order_refs = generate_insert_statements_with_unique_order_refs()

# Save insert statements to a file
output_path = r'C:\Development\Source Code\AssetTrakr\AssetTrakr\Scripts\DemoData\_Output\Contracts.sql'
with open(output_path, 'w') as file:
    for statement in insert_statements_with_unique_order_refs:
        file.write(statement + '\n')
