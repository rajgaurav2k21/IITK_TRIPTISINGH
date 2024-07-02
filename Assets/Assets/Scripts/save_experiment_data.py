import csv
import time
import sys

def save_data_to_csv(participant_id, condition, reaction_time, accuracy, error_distance, feedback):
    timestamp = time.strftime("%Y-%m-%d %H:%M:%S")
    data = [participant_id, condition, reaction_time, accuracy, error_distance, feedback, timestamp]
    
    with open('experiment_data.csv', mode='a', newline='') as file:
        writer = csv.writer(file)
        writer.writerow(data)

# Main entry point for the script
if __name__ == "__main__":
    participant_id = sys.argv[1]
    condition = sys.argv[2]
    reaction_time = float(sys.argv[3])
    accuracy = sys.argv[4]
    error_distance = float(sys.argv[5])
    feedback = sys.argv[6]

    save_data_to_csv(participant_id, condition, reaction_time, accuracy, error_distance, feedback)
