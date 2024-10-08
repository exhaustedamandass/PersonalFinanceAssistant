import React, { useEffect, useState } from 'react';
import axios from 'axios';

// Define the Account interface for type safety
interface Account {
    id: string;
    name: string;
    balance: number;
}

const Accounts: React.FC = () => {
    const [accounts, setAccounts] = useState<Account[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        axios.get('/api/Account')
            .then(response => {
                setAccounts(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error fetching accounts:', error);
                setError('Failed to load accounts');  // Set error message
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading accounts...</p>;
    }

    if (error) {
        return <p>{error}</p>;  // Display the error message if any
    }

    return (
        <div>
            <h2>Accounts List</h2>
            <ul>
                {accounts.map(account => (
                    <li key={account.id}>
                        <p><strong>{account.name}</strong></p>
                        <p>Balance: {account.balance.toFixed(2)}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Accounts;
