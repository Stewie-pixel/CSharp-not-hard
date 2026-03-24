#!/bin/bash

# Configuration
INTERVAL=30 # Seconds between checks

echo "Starting auto-commit script..."
echo "Interval: $INTERVAL seconds"

while true; do
    # Check if there are any changes (including untracked files)

    FILES=$(git ls-files -o -m --exclude-standard)

    if [ -z "$FILES" ]; then
      echo "No changes to commit!"
      exit 0
    fi
    
    for file in $FILES; do
      # Stage the file
      git add "$file"
    
      # Generate a simple commit message from file name
      # Replace underscores and remove extensions for readability
      FILENAME=$(basename "$file")
      MESSAGE=$(echo "$FILENAME" | sed 's/_/ /g' | sed 's/\..*$//')
      
      git commit -m "feat: add $MESSAGE as first commit"
   
      echo "Committed $file as '$MESSAGE'"
      
    done
    
    echo "All files committed separately."

    if [[ -n $(git status -s) ]]; then
        echo "Changes detected. Committing..."
    fi
    # Wait for the next interval
    sleep $INTERVAL
done