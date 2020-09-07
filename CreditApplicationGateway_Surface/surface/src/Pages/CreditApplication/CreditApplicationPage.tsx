import { Input, Col, Row, InputNumber, Button, Alert } from 'antd';
import React, { useState } from 'react';
import { GetCreditApplication } from '../../Services/CreditApplication/CreditApplicationService';
import { CreditApplicationRequest } from '../../Models/CreditApplication/Request/CreditApplicationRequest';

const CreditApplicationPage = (): JSX.Element => {

    const [identityNumber, setIdentityNumber] = useState<string>("");
    const [name, setName] = useState<string>("");
    const [surname, setSurname] = useState<string>("");
    const [phoneNumber, setPhoneNumber] = useState<string>("");
    const [salary, setSalary] = useState<number>(0);
    const [isMessageVisible, setIsMessageVisible] = useState(false);
    const [isFailed, setIsFailed] = useState(false);
    const [creditScore, setCreditScore] = useState(0);

    const saveEvent = () => {
        const request: CreditApplicationRequest = {
            identityNumber: identityNumber,
            name: name,
            surname: surname,
            phoneNumber: phoneNumber,
            salary: salary
        }
        GetCreditApplication(request).then((response: any) => {
            setIsFailed(response.creditApplicationResult);
            setIsMessageVisible(true);
        }).catch((e: Error) => {
            console.error(e);
        });
    }

    return (
        <div>
            <Row>
                <Col>
                    Identity Number
                    <Input allowClear maxLength={11} onChange={((e: any) => {
                        setIdentityNumber(e.target.value);
                    })}/>
                </Col>
            </Row>
            <Row>
                <Col>
                    Name 
                    <Input allowClear onChange={((e: any) => {
                        setName(e.target.value);
                    })}></Input>
                </Col>
                <Col>
                    Surname 
                    <Input allowClear onChange={((e: any) => {
                        setSurname(e.target.value);
                    })}></Input>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Row>Salary</Row>
                    <InputNumber onChange={((e: any) => {
                        setSalary(e);
                    })}>
                    </InputNumber>
                </Col>
            </Row>
            <Row>
                <Col>
                    <Row>Phone Number</Row> 
                    <Input defaultValue="05XXXXXXXXX" allowClear maxLength={11} onChange={((e: any) => {
                        setPhoneNumber(e.target.value);
                    })}/>
                </Col>
            </Row>
            <Row>
                <Button onClick={saveEvent} type='primary'>
                    Apply
                </Button>
            </Row>
            {
                isMessageVisible &&
                <Alert
                    message= {isFailed ? "İşlem Başarısız !" : "İşlem Başarılı, Limitiniz: " + creditScore}
                    type={isFailed ? "error" : "warning"}
                    closable
                    onClose={(() => {setIsMessageVisible(false)})}
                />
            }
        </div>
    );
}

export default CreditApplicationPage;